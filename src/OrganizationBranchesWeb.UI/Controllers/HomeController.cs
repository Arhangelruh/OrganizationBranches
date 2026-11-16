using Microsoft.AspNetCore.Mvc;
using OrganizationBranchesWeb.Application.Interfaces;
using OrganizationBranchesWeb.UI.ViewModels;

namespace OrganisationBranchesWeb.UI.Controllers
{
	public class HomeController(IDepartmentService departmentService) : Controller
	{
		private readonly IDepartmentService _departmentService = departmentService ?? throw new ArgumentNullException(nameof(departmentService));
		public async Task<IActionResult> Index()
		{
			var departments = await _departmentService.GetAllDepartmentsAsync();

			List<DepartmentFullViewModel> viewModels = [];

			if(departments.Count > 0)
			{
				foreach (var department in departments) {

					var cashes = new List<CashViewModel>();

					if (department.Cashes.Count > 0) {
						foreach (var cash in department.Cashes)
						{
							cashes.Add(new CashViewModel
							{
								Id = cash.Id,
								Name = cash.Name
							});
						}
					}

					viewModels.Add(new DepartmentFullViewModel
					{ 
						Id = department.Id,
						IsOpen = department.IsOpen,
						Name = department.Name,
						Address = department.Address,
						CashCode = department.CashCode,
					    Code = department.Code,
						Cashes = cashes
					});				
				}
			}

			return View(viewModels);
		}

		public IActionResult Privacy()
		{
			return View();
		}

	}
}
