namespace TechSkills.Domain
{
    public class Course
    {
        public Guid Id { get; }

        public string Title { get; }

        public string Description { get; }

        public const int MAX_TITLE_LENGTH = 50;
        public const int MAX_DESCRIPTION_LENGTH = 300;

        private Course(Guid guid, string title, string description)
        {
            Id = guid;
            Title = title;
            Description = description;
        }

        public static (Course Course, string Error) Create(Guid guid, string title, string description)
        {
            var error = string.Empty;

            if(string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error += "Title can not be empty or longer then 50 symbols. ";
            }

            if (string.IsNullOrEmpty(description) || description.Length > MAX_DESCRIPTION_LENGTH)
            {
                error += "Title can not be empty or longer then 300 symbols. ";
            }

            var course = new Course(guid, title, description);

            return (course, error);
        }
    }
}
