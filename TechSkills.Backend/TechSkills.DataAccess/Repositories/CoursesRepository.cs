using Microsoft.EntityFrameworkCore;
using TechSkills.Domain;
using TechSkills.Domain.Abstractions;

namespace TechSkills.DataAccess.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly TechSkillsDbContext _context;

        public CoursesRepository(TechSkillsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetCourses()
        {
            var courseEntities = await _context.Courses
                .AsNoTracking()
                .ToListAsync();
            var courses = courseEntities
                .Select(x => Course.Create(Guid.NewGuid(), x.Title, x.Description).Course)
                .ToList();

            return courses;
        }
    }
}
