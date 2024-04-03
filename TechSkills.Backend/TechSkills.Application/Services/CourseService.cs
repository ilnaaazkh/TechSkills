using TechSkills.Domain;
using TechSkills.Domain.Abstractions;

namespace TechSkills.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICoursesRepository coursesRepository;

        public CourseService(ICoursesRepository coursesRepository)
        {
            this.coursesRepository = coursesRepository;
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await coursesRepository.GetCourses();
        }

        public async Task<Guid> CreateCourse(Course course)
        {
            return await coursesRepository.Create(course);
        }

        public async Task<Guid> UpdateCourse(Course course)
        {
            return await coursesRepository.Update(course);
        }

        public async Task<Guid> DeleteCourse(Guid CourseId)
        {
            return await coursesRepository.Delete(CourseId);
        }

    }
}
