using ASPNETBLL.DTOs.CourseQueryDto;
using ASPNETDAL.Entities;
using AutoMapper;

namespace ASPNETBLL.DTOs.Mapper;

public class MapCourseProfile : Profile
{
    public MapCourseProfile()
    {
        CreateMap<CourseRequestDto, Course>()
            .ForMember(d => d.Id, source => source.MapFrom(m => m.Id))
            .ForMember(d => d.Title, source => source.MapFrom(m => m.Title))
            .ForMember(d => d.Credits, source => source.MapFrom(m => m.Credits))
            .ForMember(d => d.Enrollments, source => source.MapFrom(m => m.Enrollments));
    }
}