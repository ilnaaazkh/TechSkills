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
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(Module.MODULE_TITLE_MAX_LENGTH);

            builder
                .HasOne(x => x.Course); //TODO: Configure this 
        }
    }
}
