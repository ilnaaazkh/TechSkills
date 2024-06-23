using Microsoft.AspNetCore.Mvc;
using TechSkills.API.Contracts.Requests;
using TechSkills.API.Contracts.Responses;
using TechSkills.Domain.Abstractions;
using TechSkills.Domain;

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
        public async Task<ActionResult<CourseResponse>> GetCourses()
        {
            var courses = await coursesService.GetAllCourses();

            var response = courses.Select(c => new CourseResponse(c.Id, c.Title, c.Description));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCourse([FromBody] CourseRequest request)
        {
            var course = Course.Create(Guid.NewGuid(), request.Title, request.Description);

            if (course.IsFailure)
            {
                return BadRequest(course.Error);
            }

            var courseId = await coursesService.CreateCourse(course.Value);

            return Ok(courseId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateBooks(Guid id, [FromBody] CourseRequest request)
        {
            var updatedCourse = Course.Create(id,
                request.Title,
                request.Description);

            if (updatedCourse.IsFailure)
            {
                return BadRequest(updatedCourse.Error);
            }

            var updatedCourseId = await coursesService.UpdateCourse(updatedCourse.Value);

            return Ok(updatedCourseId);
        } 

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteCourse(Guid id)
        {
            var courseId = await coursesService.DeleteCourse(id);

            return Ok(courseId);
        }
    }
}
