using ASPNETBLL.DTOs.StudentQueryDto;
using ASPNETDAL.Entities;
using AutoMapper;

namespace ASPNETBLL.DTOs.Mapper;

public class MapSwapStudentDto : Profile
{
    public MapSwapStudentDto()
    {
        CreateMap<StudentDto, Student>()
            .ForMember(d=> d.Id,src => src.MapFrom(s => s.Id))
            .ForMember(d => d.StudentName, src => src.MapFrom(s => s.Name))
            .ForMember(d => d.StudentCode, src => src.MapFrom(s => s.Code));
    }
}