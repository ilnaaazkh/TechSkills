using CSharpFunctionalExtensions;

namespace TechSkills.Domain
{
    public class Module
    {
        public const int MODULE_TITLE_MAX_LENGTH = 30;
        private readonly List<Lesson> lessons = new List<Lesson>();

        public Guid Id { get; }
        public string Title { get; }
        public IReadOnlyCollection<Lesson> Lessons => lessons;

        private Module(Guid Id, string title)
        {
            this.Id = Id;
            Title = title;
        }

        public static Result<Module> Create(Guid Guid, String Title)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(Title) || Title.Length > MODULE_TITLE_MAX_LENGTH)
            {
                error += $"Module title can't be empty or longer than {MODULE_TITLE_MAX_LENGTH}";
            }

            if (error != string.Empty)
            {
                return Result.Failure<Module>(error);
            }

            var module = new Module(Guid, Title);

            return Result.Success<Module>(module);
        }

        public void AddLesson(Lesson lesson)
        {
            lessons.Add(lesson);
        }
    }
}