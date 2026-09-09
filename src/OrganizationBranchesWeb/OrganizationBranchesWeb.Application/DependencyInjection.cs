using Microsoft.Extensions.DependencyInjection;
using OrganizationBranchesWeb.Application.Interfaces;
using OrganizationBranchesWeb.Application.Services;

namespace OrganizationBranchesWeb.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services) { 
		   
			services.AddScoped<ICashService, CashService>();
			services.AddScoped<IDepartmentService, DepartmentService>();
			
			return services;
		}
	}
}
