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
    }
}
