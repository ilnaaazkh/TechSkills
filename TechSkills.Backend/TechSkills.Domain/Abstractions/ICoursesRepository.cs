namespace TechSkills.Domain.Abstractions
{
    public interface ICoursesRepository
    {
        Task<List<Course>> GetCourses();
    }
}
