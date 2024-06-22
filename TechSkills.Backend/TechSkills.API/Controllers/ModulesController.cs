using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TechSkills.API.Contracts;
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

		[HttpPost]
		public async Task<ActionResult<Guid>> CreateModule([FromBody] ModuleRequest request, Guid courseId)
		{
			/*var module = Module.Create(Guid.NewGuid(), request.Title, request.OrderNumber);

			if (module.IsFailure)
			{
				return BadRequest(module.Error);
			}

			var moduleId = await moduleService.CreateModule(module.Value, Guid courseId);*/

			return Ok();
		}
	}
}
