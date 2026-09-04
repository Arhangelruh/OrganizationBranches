namespace OrganisationBranchesWeb.Domain.Model
{
	public class Cash
	{
		/// <summary>
		/// Cash Id.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Cash name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Department identifier.
		/// </summary>
		public int DepartmentId { get; set; }

		/// <summary>
		/// Navigate to department.
		/// </summary>
		public Department Department { get; set; }
	}
}
