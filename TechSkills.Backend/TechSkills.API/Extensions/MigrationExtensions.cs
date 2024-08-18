using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TechSkills.DataAccess;

namespace TechSkills.API.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using TechSkillsDbContext dbContext = scope.ServiceProvider.GetRequiredService<TechSkillsDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
