using Microsoft.Extensions.DependencyInjection;

namespace ASPNETBLL.Extentions;

public static class ExtensionLifeTimeServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        //DI Service
        /*services.AddTransient<IStudentService, StudentService>();
        services.AddTransient<IEnrollmentService, EnrollmentService>();
        services.AddTransient<ICourseServices, CourseService>();*/
        
        return services;
    }
}