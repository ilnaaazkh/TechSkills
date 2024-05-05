using CSharpFunctionalExtensions;
using TechSkills.Domain.Enums;

namespace TechSkills.Domain
{
    public class Lesson
    {
        public const int LESSON_TITLE_MAX_LENGTH = 30;
        public Guid Id { get; }
        public string Title { get; }
        public string Content { get; }
        public int OrderNumber { get; set; }
        public LessonType LessonType { get; }

        private Lesson(Guid Id, string Title, string Content, int OrderNumber, LessonType LessonType)
        {
            this.Id = Id;
            this.Title = Title; 
            this.Content = Content;
            this.OrderNumber = OrderNumber;
            this.LessonType = LessonType;
        }

        public static Result<Lesson> Create(Guid Id, string Title, string Content, int OrderNumber, LessonType LessonType = LessonType.Theory)
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

            var lesson = new Lesson(Id, Title, Content, OrderNumber, LessonType);
            return Result.Success<Lesson>(lesson);
        }
    }
}