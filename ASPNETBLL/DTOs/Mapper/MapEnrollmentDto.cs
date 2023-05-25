using ASPNETBLL.DTOs.EnrollmentQueryDto;
using ASPNETDAL.Entities;
using AutoMapper;

namespace ASPNETBLL.DTOs.Mapper;

public class MapEnrollmentDto : Profile
{
    public MapEnrollmentDto()
    {
        CreateMap<Enrollment, EnrollmentDto>()
            .ForMember(d => d.Grade, source => source.MapFrom(m => m.Grade))
            .ForMember(d => d.CourseTitle, sorce => sorce.MapFrom(e => e.Course));
    }
}