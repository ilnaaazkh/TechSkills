using CSharpFunctionalExtensions;

namespace TechSkills.Domain
{
    public class Lesson
    {
        public const int LESSON_TITLE_MAX_LENGTH = 30;
        public Guid Id { get; }
        public string Title { get; }
        public string Content { get; }
        public int OrderNumber { get; set; }

        private Lesson(Guid Id, string Title, string Content, int OrderNumber)
        {
            this.Id = Id;
            this.Title = Title; 
            this.Content = Content;
            this.OrderNumber = OrderNumber;
        }

        public static Result<Lesson> Create(Guid Id, string Title, string Content, int OrderNumber)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(Title) || Title.Length > LESSON_TITLE_MAX_LENGTH)
            {
                error += $"Lesson title can't be empty or longer than {LESSON_TITLE_MAX_LENGTH} ";
            }

            if( OrderNumber < 0)
            {
                error += $"Lesson order number must be non-negative integer number";
            }

            if (!string.IsNullOrEmpty(error))
            {
                return Result.Failure<Lesson>(error);
            }

            var lesson = new Lesson(Id, Title, Content, OrderNumber);
            return Result.Success<Lesson>(lesson);
        }
    }
}