using CSharpFunctionalExtensions;
using TechSkills.Domain.Enums;

namespace TechSkills.Domain
{
    public class Course
    {
        public const int MAX_TITLE_LENGTH = 50;
        public const int MAX_DESCRIPTION_LENGTH = 300;


        private readonly List<Module> modules = new List<Module>();
       


        public Guid Id { get; }
        public string Title { get; }
        public string Description { get; }
        public PublishState PublishState { get; }
        public IReadOnlyCollection<Module> Modules => modules;
        


        private Course(Guid guid, string title, string description, PublishState publishState)
        {
            Id = guid;
            Title = title;
            Description = description;
            PublishState = publishState;
        }
        public void AddModules(Module module)
        {
            modules.Add(module);
        }

        public static Result<Course> Create(Guid guid, string title, string description, PublishState publishState = PublishState.Draft)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error += $"Title can not be empty or longer than {MAX_TITLE_LENGTH} symbols. ";
            }

            if (string.IsNullOrEmpty(description) || description.Length > MAX_DESCRIPTION_LENGTH)
            {
                error += $"Title can not be empty or longer than {MAX_DESCRIPTION_LENGTH} symbols. ";
            }

            if(error != string.Empty)
            {
                return Result.Failure<Course>(error);
            }

            var course = new Course(guid, title, description, publishState);

            return Result.Success<Course>(course);
        }
    }
}
