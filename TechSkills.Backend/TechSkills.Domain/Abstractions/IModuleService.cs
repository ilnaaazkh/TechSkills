
namespace TechSkills.Domain.Abstractions
{
	public interface IModuleService
	{
		Task<List<Module>> GetModulesByCourseId(Guid CourseId);
	}
}
