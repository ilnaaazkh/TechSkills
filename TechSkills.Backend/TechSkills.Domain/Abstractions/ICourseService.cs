using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSkills.Domain.Abstractions
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllCourses();
        Task<Guid> CreateCourse(Course course);
        Task<Guid> UpdateCourse(Course course);
        Task<Guid> DeleteCourse(Guid CourseId);
    }
}
