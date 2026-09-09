using Microsoft.EntityFrameworkCore;
using OrganizationBranchesWeb.Application.DTOModels;
using OrganizationBranchesWeb.Application.Interfaces;
using OrganizationBranchesWeb.Domain.Model;

namespace OrganizationBranchesWeb.Application.Services
{
	public class CashService(IApplicationDbContext db) : ICashService
	{
		private readonly IApplicationDbContext _db = db ?? throw new ArgumentNullException(nameof(db));
		
		public async Task AddCashAsync(CashDto cash)
		{
			ArgumentNullException.ThrowIfNull(cash);

			var newCash = new Cash
			{
				Name = cash.Name,
				DepartmentId = cash.DepartmentId
			};

			_db.Cashes.Add(newCash);
			await _db.SaveChangesAsync();
		}

		public async Task DeleteCashAsync(int cashId)
		{
			await _db.Cashes
					.Where(c => c.Id == cashId)
					.ExecuteDeleteAsync();
		}

		public async Task EditCashAsync(CashDto cash)
		{
			ArgumentNullException.ThrowIfNull(cash);

			var getCash = _db.Cashes.FirstOrDefault(c => c.Id == cash.Id);

			if (getCash != null) { 
			  
				getCash.Name = cash.Name;

				await _db.SaveChangesAsync();
			}
		}

		public async Task<CashDto?> GetCashByIdAsync(int cashId)
		{
			return await _db.Cashes
				.AsNoTracking()
				.Where(c => c.Id == cashId)
				.Select(c => new CashDto
				{
					Id = c.Id,
					Name = c.Name,					
				})
				.FirstOrDefaultAsync();
		}

		public async Task<List<CashDto>> GetCashesByDepartmentAsync(int departmentId)
		{
			return await _db.Cashes
				.AsNoTracking()
				.Where(c=>c.DepartmentId == departmentId)
				.Select(c=> new CashDto
				{
					Id = c.Id,
					Name = c.Name,
					DepartmentId = c.DepartmentId
				})
				.ToListAsync();
		}
	}
}
