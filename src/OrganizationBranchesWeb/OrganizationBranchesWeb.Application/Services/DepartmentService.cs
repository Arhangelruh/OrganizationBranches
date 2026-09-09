using OrganizationBranchesWeb.Application.DTOModels;
using OrganizationBranchesWeb.Application.Interfaces;
using OrganizationBranchesWeb.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace OrganizationBranchesWeb.Application.Services
{
	public class DepartmentService(IApplicationDbContext db) : IDepartmentService
	{
		private readonly IApplicationDbContext _db = db ?? throw new ArgumentNullException(nameof(db));

		public async Task AddDepartmentAsync(DepartmentDto department)
		{
			ArgumentNullException.ThrowIfNull(department);

			var newDepartment = new Department { 
			  Name = department.Name,
			  Address = department.Address,
			  Code = department.Code,
			  CashCode = department.CashCode,
			  IsOpen = true
			};

			_db.Departments.Add(newDepartment);
			await _db.SaveChangesAsync();
		}

		public async Task DeleteDepartmentAsync(int departmentId)
		{
			await _db.Departments
					.Where(d => d.Id == departmentId)
					.ExecuteDeleteAsync();
		}

		public async Task EditDepartmentAsync(DepartmentDto department)
		{
			ArgumentNullException.ThrowIfNull(department);

			var getDepartment = _db.Departments.FirstOrDefault(d=>d.Id == department.Id);

			if (getDepartment != null) { 
			    getDepartment.Name = department.Name;
				getDepartment.Address = department.Address;
				getDepartment.Code = department.Code;
				getDepartment.CashCode = department.CashCode;

				await _db.SaveChangesAsync();
			}
		}

		public async Task<List<DepartmentDto>> GetAllDepartmentsAsync()
		{
			var result = await _db.Departments
				.AsNoTracking()
				.Select(d=>new DepartmentDto
				{
					Id = d.Id,
					Name = d.Name,
					Address = d.Address,
					Code = d.Code,
					CashCode = d.CashCode,
					IsOpen = d.IsOpen,
					Cashes = d.Cashes
					.Select(c=> new CashDto{ 
						Id = c.Id,
						DepartmentId = c.DepartmentId,
						Name = c.Name
					})
					.ToList()
				})
				.ToListAsync();

			return result;
		}

		public async Task<List<DepartmentDto>> GetAllOpenDepartmentsAsync()
		{
			var result = await _db.Departments
				.AsNoTracking()
				.Where(d=> d.IsOpen == true)
				.Select(d => new DepartmentDto
				{
					Id = d.Id,
					Name = d.Name,
					Address = d.Address,
					Code = d.Code,
					CashCode = d.CashCode,
					IsOpen = d.IsOpen,
					Cashes = d.Cashes
					.Select(c => new CashDto
					{
						Id = c.Id,
						DepartmentId = c.DepartmentId,
						Name = c.Name
					})
					.ToList()
				})
				.ToListAsync();

			return result;
		}

		public async Task<DepartmentDto?> GetDepartmentByIdAsync(int departmentId)
		{
			return await _db.Departments
				.AsNoTracking()
				.Where(dep => dep.Id == departmentId)
				.Select(dep => new DepartmentDto
				{
					Id = dep.Id,
					Name = dep.Name,
					Address = dep.Address,
					IsOpen = dep.IsOpen,
					Code = dep.Code,
					CashCode = dep.CashCode
				})
				.FirstOrDefaultAsync();
		}

		public async Task ChangeDepartmentStatusAsync(int departmentId) {

			var dep = await _db.Departments.FirstOrDefaultAsync(c => c.Id == departmentId);
			if (dep != null)
			{
				dep.IsOpen = !dep.IsOpen;
				await _db.SaveChangesAsync();
			}
		}
	}
}
