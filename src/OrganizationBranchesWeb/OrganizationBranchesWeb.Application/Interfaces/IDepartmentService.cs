using OrganizationBranchesWeb.Application.DTOModels;
using OrganizationBranchesWeb.Domain.Model;

namespace OrganizationBranchesWeb.Application.Interfaces
{
	public interface IDepartmentService
	{
		/// <summary>
		/// Get all departments.
		/// </summary>
		/// <returns>List of departments</returns>
		Task<List<DepartmentDto>> GetAllDepartmentsAsync();

		/// <summary>
		/// Get all open departments.
		/// </summary>
		/// <returns>List of departments</returns>
		Task<List<DepartmentDto>> GetAllOpenDepartmentsAsync();

		/// <summary>
		/// Add department.
		/// </summary>
		/// <param name="department">Department dto</param>
		/// <returns></returns>
		Task AddDepartmentAsync(DepartmentDto department);

		/// <summary>
		/// Edit department.
		/// </summary>
		/// <param name="department">Department dto</param>
		/// <returns></returns>
		Task EditDepartmentAsync(DepartmentDto department);

		/// <summary>
		/// Get department.
		/// </summary>
		/// <param name="departmentId">Department id</param>
		/// <returns>Department dto</returns>
		Task<DepartmentDto?> GetDepartmentByIdAsync(int departmentId);

		/// <summary>
		/// Delete department.
		/// </summary>
		/// <param name="departmentId">Department id</param>
		/// <returns></returns>
		Task DeleteDepartmentAsync(int departmentId);

		/// <summary>
		/// Change status.
		/// </summary>
		/// <param name="departmentId">Department Id</param>
		/// <returns></returns>
		Task ChangeDepartmentStatusAsync(int departmentId);
	}
}
