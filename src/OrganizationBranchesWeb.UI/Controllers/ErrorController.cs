using Microsoft.AspNetCore.Mvc;
using ServicePortal.UI.Models;

namespace OrganizationBranchesWeb.UI.Controllers
{
	public class ErrorController : Controller
	{
		/// <summary>
		/// If there is 404 status code, the route path will become Error/404
		/// </summary>
		/// <param name="statusCode"></param>
		/// <returns>Error view</returns>
		[Route("Error/{statusCode:int}")]
		public IActionResult Error(int statusCode)
		{
			var model = statusCode switch
			{
				404 => new ErrorPageModel
				{
					StatusCode = 404,
					Title = "Страница не найдена.",
					Message = "Запрашиваемая страница не найдена"
				},

				400 => new ErrorPageModel
				{
					StatusCode = 400,
					Title = "Ошибка запроса",
					Message = "Ошибка запроса, обратитесь в тех поддержку."
				},

				_ => new ErrorPageModel
				{
					StatusCode = statusCode,
					Title = "Ошибка запроса",
					Message = "Ошибка запроса, обратитесь в тех поддержку."
				}
			};

			return View(model);
		}
	}
}
