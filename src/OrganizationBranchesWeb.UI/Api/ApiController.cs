using Microsoft.AspNetCore.Mvc;
using OrganizationBranchesWeb.Application.DTOModels;
using OrganizationBranchesWeb.Application.Interfaces;

namespace OrganizationBranchesWeb.UI.Api
{
	[Route("api/departments")]
	[ApiController]
	public class ApiController(IDepartmentService departmentService) : ControllerBase
	{
		private readonly IDepartmentService _departmentService = departmentService ?? throw new ArgumentNullException(nameof(departmentService));

		[HttpGet]
		public async Task<ActionResult<List<DepartmentDto>>> GetAll()
		{
			var departments = await _departmentService.GetAllDepartmentsAsync();
			return Ok(departments);
		}
	}
}
