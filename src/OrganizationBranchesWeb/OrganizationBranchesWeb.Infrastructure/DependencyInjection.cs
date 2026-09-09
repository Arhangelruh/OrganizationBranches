using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrganizationBranchesWeb.Application.Interfaces;
using OrganizationBranchesWeb.Infrastructure.Data.Context;

namespace OrganizationBranchesWeb.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(
		this IServiceCollection services,
		IConfiguration configuration)
		{
			var connectionString =
				configuration.GetConnectionString("BranchesDatabase")
				?? Environment.GetEnvironmentVariable("BranchesDatabase");

			if (string.IsNullOrWhiteSpace(connectionString))
				throw new InvalidOperationException("Connection string is not configured.");

			services.AddDbContext<OrganizationBranchesAppContext>(options =>
				options.UseNpgsql(connectionString));

			services.AddScoped<IApplicationDbContext>(sp =>
			sp.GetRequiredService<OrganizationBranchesAppContext>());

			return services;
		}
	}
}
