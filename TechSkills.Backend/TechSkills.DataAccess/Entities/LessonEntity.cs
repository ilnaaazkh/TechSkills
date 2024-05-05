using TechSkills.DataAccess.Enums;

namespace TechSkills.DataAccess.Entities
{
	public class LessonEntity
	{
		public Guid Id { get; set; }
        public string  Title { get; set; }
		public string Content { get; set; }
        public LessonType LessonType { get; set; }
        public Guid ModuleId { get; set; }
        public int OrderNumber { get; set; }


        public ModuleEntity Module { get; set; }

    }
}
