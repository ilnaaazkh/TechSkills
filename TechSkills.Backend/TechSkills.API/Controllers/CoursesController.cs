using Microsoft.AspNetCore.Mvc;
using TechSkills.API.Contracts;
using TechSkills.Domain.Abstractions;

namespace TechSkills.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService coursesService;

        public CoursesController(ICourseService coursesService)
        {
            this.coursesService = coursesService;
        }

        [HttpGet]
        public async Task<ActionResult<CourseResponse>> Courses()
        {
            var courses = await coursesService.GetAllCourses();

            var response = courses.Select(c => new CourseResponse(c.Id, c.Title, c.Description));

            return Ok(response);
        }
    }
}
