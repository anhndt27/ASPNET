using ASPNETDAL.Entities;

namespace ASPNETBLL.DTOs.CourseQueryDto;

public static class CourseListDtoSelect
{
    public static IQueryable<CourseDto> MapListCouresDto(this IQueryable<Course> courses)
    {
        return courses.Select(c => new CourseDto
        {
            Id = c.Id,
            Title = c.Title,
            Credits = c.Credits,
            Student = string.Join(",", c.Enrollments!.Select(e => e.Student!.StudentName))
        });
    } 
}