using TechSkills.Domain.Enums;

namespace TechSkills.DataAccess.Entities
{
    public class CourseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public PublishState? PublishState { get; set; }


        public List<ModuleEntity> Modules { get; set; }
    }
}
