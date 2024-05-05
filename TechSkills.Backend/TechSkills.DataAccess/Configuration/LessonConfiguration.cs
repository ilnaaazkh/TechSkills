using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechSkills.DataAccess.Entities;
using TechSkills.DataAccess.Enums;
using TechSkills.Domain;

namespace TechSkills.DataAccess.Configuration
{
	public class LessonConfiguration : IEntityTypeConfiguration<LessonEntity>
	{
		public void Configure(EntityTypeBuilder<LessonEntity> builder)
		{
			builder.HasKey(lesson => lesson.Id);

			builder.Property(lesson => lesson.Title)
				.IsRequired()
				.HasMaxLength(Lesson.LESSON_TITLE_MAX_LENGTH);

			builder.Property(lesson => lesson.Content)
				.IsRequired();

			builder.Property(lesson => lesson.LessonType)
				.HasConversion<int>();
		}
	}
}
