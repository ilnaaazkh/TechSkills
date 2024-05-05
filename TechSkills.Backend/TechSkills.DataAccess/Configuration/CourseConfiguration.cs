using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechSkills.DataAccess.Entities;
using TechSkills.DataAccess.Enums;
using TechSkills.Domain;


namespace TechSkills.DataAccess.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<CourseEntity>
    {
        public void Configure(EntityTypeBuilder<CourseEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(Course.MAX_TITLE_LENGTH);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(Course.MAX_DESCRIPTION_LENGTH);

            builder.Property(x => x.PublishState)
                .HasConversion<int>()
                .HasDefaultValue(PublishState.Draft);
        }
    }
}
