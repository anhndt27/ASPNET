using ASPNETBLL.DTOs.EnrollmentQueryDto;
using ASPNETBLL.DTOs.StudentQueryDto;
using AutoMapper;

namespace ASPNETBLL.DTOs.Mapper;

public class MapStuDtoToEnDto : Profile
{
    public MapStuDtoToEnDto()
    {
        CreateMap<StudentDto, EnrollmentDto>()
            .ForMember(d => d.StudentName, src => src.MapFrom(m => m.Name))
            .ForMember(d => d.StudentCode, src => src.MapFrom(m => m.Code));
    }
}