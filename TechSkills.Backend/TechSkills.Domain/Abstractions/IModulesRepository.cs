namespace TechSkills.Domain.Abstractions
{
	public interface IModulesRepository
	{
		Task<List<Module>> getModulesByCourseId(Guid courseId);
	}
}
