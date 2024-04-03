using Microsoft.EntityFrameworkCore;
using TechSkills.DataAccess.Entities;
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
                .Select(x => Course.Create(x.Id, x.Title, x.Description).Value)
                .ToList();

            return courses;
        }

        public async Task<Guid> Create(Course course)
        {
            var courseEntity = new CourseEntity(){
                    Id = course.Id,
                    Title = course.Title,
                    Description = course.Description
                };

            await _context.Courses.AddAsync(courseEntity);
            await _context.SaveChangesAsync();

            return courseEntity.Id;
        }

        public async Task<Guid> Update(Course course)
        {
            await _context.Courses
                .Where(c => c.Id == course.Id)
                .ExecuteUpdateAsync(c => c
                        .SetProperty(c => c.Title, c => course.Title)
                        .SetProperty(c => c.Description, c => course.Description));
            
            return course.Id;
        }

        public async Task<Guid> Delete(Guid Id)
        {
            await  _context.Courses
                .Where(c => c.Id == Id)
                .ExecuteDeleteAsync();

            return Id;
        }
    }
}
