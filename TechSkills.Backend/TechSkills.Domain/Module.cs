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
        public int OrderNumber { get; }

        private Module(Guid Id, string title, int OrderNumber)
        {
            this.Id = Id;
            Title = title;
            this.OrderNumber = OrderNumber;
        }

        public static Result<Module> Create(Guid Guid, String Title, int OrderNumber)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(Title) || Title.Length > MODULE_TITLE_MAX_LENGTH)
            {
                error += $"Module title can't be empty or longer than {MODULE_TITLE_MAX_LENGTH}";
            }

			if (OrderNumber < 0)
			{
				error += $"Module order number must be non-negative integer number";
			}

			if (!string.IsNullOrEmpty(error))
            {
                return Result.Failure<Module>(error);
            }

            var module = new Module(Guid, Title, OrderNumber);

            return Result.Success<Module>(module);
        }

        public void AddLesson(Lesson lesson)
        {
            lessons.Add(lesson);
        }
    }
}