using Microsoft.AspNetCore.Mvc;
using TechSkills.API.Contracts.Requests;
using TechSkills.API.Contracts.Responses;
using TechSkills.Domain.Abstractions;
using TechSkills.Domain;

namespace TechSkills.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService coursesService;

        public CoursesController(ICourseService coursesService)
        {
            this.coursesService = coursesService;
        }

        /// <summary>
        /// Получить список курсов
        /// </summary>
        /// <returns>Список курсов</returns>
        /// <response code="200">Список курсов</response>>
        [HttpGet]
        [ProducesResponseType(typeof(CourseResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<CourseResponse>> GetCourses()
        {
            var courses = await coursesService.GetAllCourses();

            var response = courses.Select(c => new CourseResponse(c.Id, c.Title, c.Description));

            return Ok(response);
        }

        /// <summary>
        /// Создание нового курса
        /// </summary>
        /// <returns>Идентификатор созданного курса</returns> 
        /// <response code="200">Курс успешно создан</response>
        /// <response code="400">Ошибочные параметры</response>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Обновить информацию о курсе
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <response code="200">Информация о курсе успешно обновлена</response>
        /// <response code="400">Ошибочные параметры</response>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Удалить курс
        /// </summary>
        /// <param name="id">Идентификатор удаленного курса</param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteCourse(Guid id)
        {
            var courseId = await coursesService.DeleteCourse(id);

            return Ok(courseId);
        }
    }
}
