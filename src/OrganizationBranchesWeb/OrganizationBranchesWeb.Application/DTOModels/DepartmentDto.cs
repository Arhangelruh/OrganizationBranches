using OrganizationBranchesWeb.Domain.Model;

namespace OrganizationBranchesWeb.Application.DTOModels
{
	public class DepartmentDto
	{
		/// <summary>
		/// Department id.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Department name.
		/// </summary>
		public string Name { get; set; } = null!;

		/// <summary>
		/// Department address.
		/// </summary>
		public string Address { get; set; } = null!;

		/// <summary>
		/// Department code.
		/// </summary>
		public int Code { get; set; }

		/// <summary>
		/// Department status.
		/// </summary>
		public bool IsOpen { get; set; }

		/// <summary>
		/// Code in cash db.
		/// </summary>
		public int CashCode { get; set; }

		/// <summary>
		/// Navigate to cashes.
		/// </summary>
		public List<CashDto> Cashes { get; set; } = [];
	}
}
