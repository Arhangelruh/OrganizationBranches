using Microsoft.EntityFrameworkCore;
using OrganizationBranchesWeb.Application.Interfaces;
using OrganizationBranchesWeb.Domain.Model;
using OrganizationBranchesWeb.Infrastructure.Data.Configurations;

namespace OrganizationBranchesWeb.Infrastructure.Data.Context
{
	public class OrganizationBranchesAppContext(DbContextOptions<OrganizationBranchesAppContext> options) : DbContext(options), IApplicationDbContext
	{
		public DbSet<Department> Departments { get; set; } = null!;

		public DbSet<Cash> Cashes { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder = modelBuilder ?? throw new ArgumentNullException(nameof(modelBuilder));

			modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
			modelBuilder.ApplyConfiguration(new CashConfiguration());

			base.OnModelCreating(modelBuilder);
		}
	}
}
