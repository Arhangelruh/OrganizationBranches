using Microsoft.AspNetCore.Mvc;
using OrganizationBranchesWeb.Application.DTOModels;
using OrganizationBranchesWeb.Application.Interfaces;
using OrganizationBranchesWeb.UI.ViewModels;
using ServicePortal.UI.Models;

namespace OrganizationBranchesWeb.UI.Controllers
{
	public class DepartmentController(IDepartmentService departmentService) : Controller
	{
		private readonly IDepartmentService _departmentService = departmentService ?? throw new ArgumentNullException(nameof(departmentService));

		/// <summary>
		/// Add department page.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult AddDepartment()
		{
			return View();
		}

		/// <summary>
		/// Add department.
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> AddDepartment(DepartmentViewModel model)
		{

			if (ModelState.IsValid)
			{
				var department = new DepartmentDto
				{
					Name = model.Name,
					Address = model.Address,
					Code = model.Code,
					CashCode = model.CashCode,
					IsOpen = true
				};

				await _departmentService.AddDepartmentAsync(department);

				return RedirectToAction("Index", "Home");
			}
			return View(model);
		}

		/// <summary>
		/// Edit department page.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> EditDepartment(int departmentId)
		{
			var department = await _departmentService.GetDepartmentByIdAsync(departmentId);
			if (department != null)
			{
				var model = new DepartmentViewModel
				{
					Id = department.Id,
					Name = department.Name,
					Address = department.Address,
					Code = department.Code,
					CashCode = department.CashCode,
					IsOpen = department.IsOpen
				};

				return View(model);
			}
			else
			{
				var error = new ErrorPageModel
				{
					StatusCode = 400,
					Title = "Ошибка",
					Message = "Департамент не найден"
				};
				return View("~/Views/Error/Error.cshtml", error);
			}
		}

		/// <summary>
		/// Edit department.
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> EditDepartment(DepartmentViewModel model)
		{
			if (ModelState.IsValid)
			{
				var department = await _departmentService.GetDepartmentByIdAsync(model.Id);
				if (department != null)
				{
					var departmentDto = new DepartmentDto
					{
						Id = department.Id,
						Name = model.Name,
						Address = model.Address,
						Code = model.Code,
						CashCode = model.CashCode,
					};

					await _departmentService.EditDepartmentAsync(departmentDto);
					return RedirectToAction("Index", "Home");
				}
				else
				{
					var error = new ErrorPageModel
					{
						StatusCode = 400,
						Title = "Ошибка",
						Message = "Департамент не найден"
					};
					return View("~/Views/Error/Error.cshtml", error);
				}
			}
			return View(model);
		}

		/// <summary>
		/// Delete department.
		/// </summary>
		/// <param name="departmentId">Department id</param>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> DeleteDepartment(int departmentId)
		{
			var department = await _departmentService.GetDepartmentByIdAsync(departmentId);
			if (department != null)
			{
				await _departmentService.DeleteDepartmentAsync(department.Id);

				return RedirectToAction("Index", "Home");
			}
			else
			{
				var error = new ErrorPageModel
				{
					StatusCode = 400,
					Title = "Ошибка",
					Message = "Департамент не найден"
				};
				return View("~/Views/Error/Error.cshtml", error);
			}
		}
	}
}
