using ASPNETBLL.DTOs.CourseQueryDto;
using ASPNETBLL.DTOs.EnrollmentQueryDto;

namespace ASPNETmvc.Models;

public class EnrollmentViewModel
{
    public IEnumerable<CourseDto> courseViewModel { get; set; }
    public EnrollmentCreateDto enrollViewModel { get; set; }
}