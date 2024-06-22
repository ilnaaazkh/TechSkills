using Microsoft.EntityFrameworkCore;
using TechSkills.Domain;
using TechSkills.Domain.Abstractions;

namespace TechSkills.DataAccess.Repositories
{
    public class ModulesRepository : IModulesRepository
    {
        private readonly TechSkillsDbContext _context;

        public ModulesRepository(TechSkillsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Module>> getModulesByCourseId(Guid courseId)
        {
            var moduleEntities = await _context.Modules
                .Where(module => module.CourseId == courseId)
                .AsNoTracking() 
                .ToListAsync();

            var modules = moduleEntities
                .Select(m => Module.Create(m.Id, m.Title, m.OrderNumber).Value)
                .ToList();

            return modules;
        }

    }
}
