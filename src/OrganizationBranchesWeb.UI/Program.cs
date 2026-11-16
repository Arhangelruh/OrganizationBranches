using NLog;
using NLog.Web;
using ServicePortal.UI.Models;
using OrganizationBranchesWeb.Infrastructure;
using OrganizationBranchesWeb.Application;


var logger = LogManager.Setup()
	.LoadConfigurationFromAppSettings()
	.GetCurrentClassLogger();

try
{

	var builder = WebApplication.CreateBuilder(args);

	builder.Logging.ClearProviders();
	builder.Host.UseNLog();
	builder.Services.AddApplication();
	builder.Services.AddInfrastructure(builder.Configuration);
	builder.Services.AddProblemDetails();

	builder.Services.AddControllersWithViews();
	builder.Services.AddScoped<AppShellState>(sp =>
	{
		var configuration = sp.GetRequiredService<IConfiguration>();
		var state = new AppShellState
		{
			ActiveItem = configuration["Application:ApplicationName"],
			ApplicatinLogo = "/images/Bank.svg",
			ApplicationName = "Департаменты",
			NavigationItems = configuration.GetSection("Services").Get<List<NavigationItem>>() ?? []
		};
		return state;
	});

	var app = builder.Build();

	if (!app.Environment.IsDevelopment())
	{
		app.UseExceptionHandler(errorApp =>
		{
			errorApp.Run(async context =>
			{
				if (context.Request.Path.StartsWithSegments("/api"))
				{
					context.Response.StatusCode = 500;

					await Results.Problem(
						statusCode: 500,
						title: "Internal Server Error"
					).ExecuteAsync(context);

					return;
				}

				context.Response.Redirect("/Error/500");
			});
		});

		app.UseHsts();
	}

	app.UseWhen(
		context => context.Request.Path.StartsWithSegments("/api"),
		api =>
		{
			api.UseStatusCodePages();
		});

	app.UseWhen(
		context => !context.Request.Path.StartsWithSegments("/api"),
		mvc =>
		{
			mvc.UseStatusCodePagesWithReExecute("/Error/{0}");
		});

	app.UseHttpsRedirection();
	app.UseRouting();
	app.UseStaticFiles();

	app.UseAuthorization();

	app.MapStaticAssets();

	app.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}")
		.WithStaticAssets();


	app.Run();
}
catch(Exception ex)
{
	logger.Error(ex, "Application stopped due to exception");
}
finally
{
	LogManager.Shutdown();
}