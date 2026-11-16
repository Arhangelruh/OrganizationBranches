using Microsoft.EntityFrameworkCore;
using OrganizationBranchesWeb.Domain.Model;

namespace OrganizationBranchesWeb.Application.Interfaces
{
	public interface IApplicationDbContext
	{
		/// <summary>
		/// Departments.
		/// </summary>
		DbSet<Department> Departments { get; }

		/// <summary>
		/// Cashes.
		/// </summary>
		DbSet<Cash> Cashes { get; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
