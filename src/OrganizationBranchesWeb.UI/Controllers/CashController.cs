using Microsoft.AspNetCore.Mvc;
using OrganizationBranchesWeb.Application.DTOModels;
using OrganizationBranchesWeb.Application.Interfaces;
using OrganizationBranchesWeb.UI.ViewModels;
using ServicePortal.UI.Models;

namespace OrganizationBranchesWeb.UI.Controllers
{
	public class CashController(ICashService cashService, IDepartmentService departmentService) : Controller
	{
		private readonly ICashService _cashService = cashService ?? throw new ArgumentNullException(nameof(cashService));
		private readonly IDepartmentService _departmentService = departmentService ?? throw new ArgumentNullException(nameof(departmentService));

		/// <summary>
		/// Add cash page.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> AddCash(int departmentId)
		{
			var department = await _departmentService.GetDepartmentByIdAsync(departmentId);
			if (department != null)
			{
				return View();
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
		/// Add cash.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> AddCash(CashViewModel model)
		{

			if (ModelState.IsValid)
			{
				var department = await _departmentService.GetDepartmentByIdAsync(model.DepartmentId);
				if (department != null)
				{
					var cash = new CashDto
					{
						Name = model.Name,
						DepartmentId = model.DepartmentId
					};

					await _cashService.AddCashAsync(cash);

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
		/// Edit cash page.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> EditCash(int cashId)
		{
			var cash = await _cashService.GetCashByIdAsync(cashId);
			if (cash != null)
			{
				var model = new CashViewModel
				{
					Id = cash.Id,
					Name = cash.Name
				};

				return View(model);
			}
			else
			{
				var error = new ErrorPageModel
				{
					StatusCode = 400,
					Title = "Ошибка",
					Message = "Касса не найдена"
				};
				return View("~/Views/Error/Error.cshtml", error);
			}
		}

		/// <summary>
		/// Edit cash.
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> EditCash(CashViewModel model)
		{
			if (ModelState.IsValid)
			{
				var cash = await _cashService.GetCashByIdAsync(model.Id);
				if (cash != null)
				{
					var cashDto = new CashDto
					{
						Id = cash.Id,
						Name = model.Name,
					};

					await _cashService.EditCashAsync(cashDto);
					return RedirectToAction("Index", "Home");
				}
				else
				{
					var error = new ErrorPageModel
					{
						StatusCode = 400,
						Title = "Ошибка",
						Message = "Касса не найдена"
					};
					return View("~/Views/Error/Error.cshtml", error);
				}
			}
			return View(model);
		}

		/// <summary>
		/// Delete cash.
		/// </summary>
		/// <param name="cashId">Cash id</param>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> DeleteCash(int cashId)
		{
			var cash = await _cashService.GetCashByIdAsync(cashId);
			if (cash != null)
			{
				await _cashService.DeleteCashAsync(cash.Id);

				return RedirectToAction("Index", "Home");
			}
			else
			{
				var error = new ErrorPageModel
				{
					StatusCode = 400,
					Title = "Ошибка",
					Message = "Касса не найдена"
				};
				return View("~/Views/Error/Error.cshtml", error);
			}
		}
	}
}
