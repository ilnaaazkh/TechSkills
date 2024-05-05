using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechSkills.DataAccess.Entities;
using TechSkills.Domain;
using TechSkills.Domain.Enums;


namespace TechSkills.DataAccess.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<CourseEntity>
    {
        public void Configure(EntityTypeBuilder<CourseEntity> builder)
        {
            builder.HasKey(course => course.Id);

            builder.Property(course => course.Title)
                .IsRequired()
                .HasMaxLength(Course.MAX_TITLE_LENGTH);

            builder.Property(course => course.Description)
                .IsRequired()
                .HasMaxLength(Course.MAX_DESCRIPTION_LENGTH);

            builder.Property(course => course.PublishState)
                .HasConversion<int>()
                .HasDefaultValue(PublishState.Draft);

            builder.HasMany(course => course.Modules)
                .WithOne(module => module.Course);
        }
    }
}
