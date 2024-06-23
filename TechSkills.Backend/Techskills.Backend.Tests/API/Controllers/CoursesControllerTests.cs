using TechSkills.Domain.Abstractions;
using Xunit;
using Moq;
using TechSkills.API.Controllers;
using Bogus;
using TechSkills.Domain;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using TechSkills.API.Contracts.Responses;

namespace TechSkills.Backend.Tests.API.Controllers
{
    public class CoursesControllerTests
    {
        private readonly Mock<ICourseService> _mockCoursesService;
        private readonly CoursesController _coursesController;
        private readonly Faker<Course> _faker;

        public CoursesControllerTests()
        {
            _mockCoursesService = new Mock<ICourseService>();

            _coursesController = new CoursesController(_mockCoursesService.Object);

            _faker = new Faker<Course>()
                .CustomInstantiator(f =>
                {
                    var id = Guid.NewGuid();
                    var title = f.Lorem.Sentence(Course.MAX_TITLE_LENGTH / 10);
                    var description = f.Lorem.Paragraph(Course.MAX_DESCRIPTION_LENGTH / 100);
                    var result = Course.Create(id, title, description);

                    if (!result.IsSuccess)
                    {
                        throw new Exception(result.Error);
                    }

                    return result.Value;
                });
        }

        [Fact]
        public async Task GetCourses_ReturnsOkWithCoursesResponses()
        {
            //Arrange
            var fakeCourses = _faker.Generate(5);

            _mockCoursesService
                .Setup(service => service.GetAllCourses())
                .ReturnsAsync(fakeCourses);

            //Act

            var result = await _coursesController.GetCourses();

            //Assert
            var okResult = result.Result as OkObjectResult;

            okResult.Should().NotBeNull();
            okResult.StatusCode.Should().Be(200);


            var courses = okResult.Value as IEnumerable<CourseResponse>;
            courses.Should().NotBeNull();
            courses.Count().Should().Be(5);
            courses.Should().BeEquivalentTo(fakeCourses, options => options
                .ExcludingMissingMembers());

            _mockCoursesService.Verify(service => service.GetAllCourses(), Times.Once);
        }
    }
}
