using ASPNETBLL.DTOs.CourseQueryDto;
using ASPNETBLL.DTOs.EnrollmentQueryDto;
using AutoMapper;

namespace ASPNETBLL.DTOs.Mapper;

public class MapCourseDtoToEnDto : Profile
{
    public MapCourseDtoToEnDto()
    {
        CreateMap<CourseDto, EnrollmentDto>()
            .ForMember(d => d.CourseTitle, src => src.MapFrom(m => m.Title))
            .ForMember(d => d.CourseCredit, src => src.MapFrom(m => m.Credits));
    }
}