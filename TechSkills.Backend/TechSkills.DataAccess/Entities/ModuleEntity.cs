namespace TechSkills.DataAccess.Entities
{
    public class ModuleEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid CourseId { get; set; }
        public int OrderNumber { get; set; }


        public CourseEntity Course { get; set; }
        public List<LessonEntity> Lessons { get; set; }
    }
}
