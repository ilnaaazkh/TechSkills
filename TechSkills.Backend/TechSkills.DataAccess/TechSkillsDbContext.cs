﻿using Microsoft.EntityFrameworkCore;
using TechSkills.DataAccess.Configuration;
using TechSkills.DataAccess.Entities;

namespace TechSkills.DataAccess
{
    public class TechSkillsDbContext : DbContext
    {
        public DbSet<CourseEntity> Courses { get; set; }
        public TechSkillsDbContext(DbContextOptions<TechSkillsDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
        }
    }
}
