namespace OrganizationBranchesWeb.UI.ViewModels
{
	public class CashViewModel
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
		/// Department Id.
		/// </summary>
		public int DepartmentId { get; set; }
	}
}
