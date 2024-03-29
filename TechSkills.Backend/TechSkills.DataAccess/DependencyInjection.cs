using Microsoft.Extensions.DependencyInjection;
using TechSkills.DataAccess.Repositories;
using TechSkills.Domain.Abstractions;

namespace TechSkills.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services.AddScoped<ICoursesRepository, CoursesRepository>(); //Scoped | Transient ?
            return services;
        }
    }
}
