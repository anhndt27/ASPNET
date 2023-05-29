using ASPNETBLL.Interface;
using ASPNETBLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ASPNETBLL.Extentions;

public static class ExtensionLifeTimeServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        //DI Service
        /*services.AddTransient<IStudentServices, StudentServices>();
        services.AddTransient<IEnrollmentServices, EnrollmentServices>();*/
        //services.AddTransient<ICourseServices, CourseServices>();
        
        return services;
    }
}