namespace OrganizationBranchesWeb.Application.DTOModels
{
	public class CashDto
	{
		/// <summary>
		/// Cash Id.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Cash name.
		/// </summary>
		public string Name { get; set; } = null!;

		/// <summary>
		/// Department identifier.
		/// </summary>
		public int DepartmentId { get; set; }
	}
}
