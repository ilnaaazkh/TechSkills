using Microsoft.Extensions.DependencyInjection;
using TechSkills.Application.Services;
using TechSkills.Domain.Abstractions;

namespace TechSkills.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICourseService, CourseService>(); // Scoped | Transient ?

            return services;
        }
    }
}
