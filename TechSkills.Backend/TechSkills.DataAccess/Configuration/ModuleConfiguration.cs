using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechSkills.DataAccess.Entities;
using TechSkills.Domain;

namespace TechSkills.DataAccess.Configuration
{
	public class ModuleConfiguration : IEntityTypeConfiguration<ModuleEntity>
    {
        public void Configure(EntityTypeBuilder<ModuleEntity> builder)
        {
            builder.HasKey(module => module.Id);

            builder.Property(module => module.Title)
                .IsRequired()
                .HasMaxLength(Module.MODULE_TITLE_MAX_LENGTH);

            builder.Property(module => module.OrderNumber)
                .IsRequired();

            builder.HasMany(module => module.Lessons)
                .WithOne(lesson => lesson.Module); 
        }
    }
}
