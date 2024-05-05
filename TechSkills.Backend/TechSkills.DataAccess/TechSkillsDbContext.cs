using Microsoft.EntityFrameworkCore;
using TechSkills.DataAccess.Configuration;
using TechSkills.DataAccess.Entities;

namespace TechSkills.DataAccess
{
    public class TechSkillsDbContext : DbContext
    {
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<ModuleEntity> Modules { get; set; }
        public DbSet<LessonEntity> Lessons { get; set; }

        public TechSkillsDbContext(DbContextOptions<TechSkillsDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new CourseConfiguration())
                .ApplyConfiguration(new ModuleConfiguration())
                .ApplyConfiguration(new LessonConfiguration());
        }
    }
}
