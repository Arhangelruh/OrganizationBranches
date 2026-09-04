using System.Security.Principal;

namespace OrganisationBranchesWeb.Domain.Model
{
	public class Department
	{
		/// <summary>
		/// Department id.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Department name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Department address.
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// Department code.
		/// </summary>
		public int Code { get; set; }

		/// <summary>
		/// Cash id.
		/// </summary>
		public int CashId { get; set; }

		/// <summary>
		/// Navigate to cashes.
		/// </summary>
		public ICollection<Cash> Cashes { get; set; }
	}
}
