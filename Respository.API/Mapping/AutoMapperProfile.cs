using AutoMapper;
using Respository.API.Models.Domain;
using Respository.API.Models.DTO;

namespace Respository.API.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Enrollment, EnrollmentDTO>().ReverseMap();
            CreateMap<Course, CourseDTO>().ReverseMap();
        }
    }
}
