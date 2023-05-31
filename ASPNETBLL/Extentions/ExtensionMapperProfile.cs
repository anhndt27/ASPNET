using ASPNETBLL.DTOs.Mapper;
using ASPNETBLL.Interface;
using ASPNETBLL.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;

namespace ASPNETBLL.Extentions;

public static class ExtensionMapperProfile
{
    public static IServiceCollection AddMapper(this IServiceCollection autoMapper)
    {
        //DI Service
        autoMapper.AddAutoMapper(c => c.AddProfile<MapEnrollmentDto>(), typeof(Program));
        autoMapper.AddAutoMapper(c => c.AddProfile<MapCourseDtoToEnDto>(), typeof(Program));
        autoMapper.AddAutoMapper(c => c.AddProfile<MapCourseProfile>(), typeof(Program));
        autoMapper.AddAutoMapper(c => c.AddProfile<MapCourseDto>(), typeof(Program));
        autoMapper.AddAutoMapper(c => c.AddProfile<MapStudentDto>(), typeof(Program));
        autoMapper.AddAutoMapper(c => c.AddProfile<MapSwapStudentDto>(), typeof(Program));
        autoMapper.AddAutoMapper(c => c.AddProfile<MapStuDtoToEnDto>(), typeof(Program));

        return autoMapper;
    }
}