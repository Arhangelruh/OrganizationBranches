using OrganizationBranchesWeb.Application.DTOModels;

namespace OrganizationBranchesWeb.Application.Interfaces
{
	public interface ICashService
	{
		/// <summary>
		/// Get cashes by department id.
		/// </summary>
		/// <param name="departmentId">Department id</param>
		/// <returns></returns>
		Task<List<CashDto>> GetCashesByDepartmentAsync(int departmentId);

		/// <summary>
		/// Add cash.
		/// </summary>
		/// <param name="cash">Cash dto</param>
		/// <returns></returns>
		Task AddCashAsync(CashDto cash);

		/// <summary>
		/// Delete cash.
		/// </summary>
		/// <param name="cashId">Cash id</param>
		/// <returns></returns>
		Task DeleteCashAsync(int cashId);

		/// <summary>
		/// Edit cash.
		/// </summary>
		/// <param name="cash">Cash dto</param>
		/// <returns></returns>
		Task EditCashAsync(CashDto cash);

		/// <summary>
		/// Get cash by cash id.
		/// </summary>
		/// <param name="cashId">Cash id</param>
		/// <returns></returns>
		Task<CashDto?> GetCashByIdAsync(int cashId);
	}
}
