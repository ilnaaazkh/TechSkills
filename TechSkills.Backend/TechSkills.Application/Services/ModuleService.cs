using TechSkills.Domain;
using TechSkills.Domain.Abstractions;

namespace TechSkills.Application.Services
{
	public class ModuleService : IModuleService
	{
		private readonly IModulesRepository _modulesRepository;

        public ModuleService(IModulesRepository modulesRepository)
        {
            _modulesRepository = modulesRepository;
        }

        public async Task<List<Module>> GetModulesByCourseId(Guid CourseId)
        {
            return await _modulesRepository.getModulesByCourseId(CourseId);
        } 
    }
}
