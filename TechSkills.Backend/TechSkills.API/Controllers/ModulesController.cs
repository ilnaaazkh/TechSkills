using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TechSkills.API.Contracts.Requests;
using TechSkills.API.Contracts.Responses;
using TechSkills.Domain;
using TechSkills.Domain.Abstractions;

namespace TechSkills.API.Controllers
{
	[ApiController]
	[Route("api/Courses/{courseId:guid}/[controller]")]
	public class ModulesController : ControllerBase
	{
		private readonly IModuleService moduleService;
        public ModulesController(IModuleService moduleService)
        {
			this.moduleService = moduleService;
        }

        [HttpGet]
		public async Task<ActionResult<List<ModuleResponse>>> GetCourseModules(Guid courseId)
		{
			var modules = await moduleService.GetModulesByCourseId(courseId);

			var response = modules.Select(module => new ModuleResponse(module.Id, module.Title));

			return Ok(response);
		}
	}
}
