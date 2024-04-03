namespace TechSkills.Domain.Abstractions
{
    public interface ICoursesRepository
    {
        Task<List<Course>> GetCourses();
        Task<Guid> Create(Course course);
        Task<Guid> Update(Course course);
        Task<Guid> Delete(Guid Id);
    }
}