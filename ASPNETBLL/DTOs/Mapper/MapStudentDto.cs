using ASPNETBLL.DTOs.StudentQueryDto;
using ASPNETDAL.Entities;
using AutoMapper;

namespace ASPNETBLL.DTOs.Mapper;

public class MapStudentDto : Profile
{
    public MapStudentDto()
    {
        CreateMap<Student, StudentDto>()
            .ForMember(d => d.Id, src => src.MapFrom(s => s.Id))
            .ForMember(d => d.Name, src => src.MapFrom(s => s.StudentName))
            .ForMember(d => d.Code, src => src.MapFrom(s => s.StudentCode));
    }
}