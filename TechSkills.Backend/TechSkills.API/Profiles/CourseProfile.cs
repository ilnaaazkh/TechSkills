using AutoMapper;
using TechSkills.API.Contracts.ResponseContracts;
using TechSkills.Domain;

namespace TechSkills.API.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseResponse>();
        }
    }
}
