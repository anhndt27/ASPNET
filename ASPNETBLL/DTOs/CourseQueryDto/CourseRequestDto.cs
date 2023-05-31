namespace ASPNETBLL.DTOs.CourseQueryDto;

public class CourseRequestDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public double Credits { get; set; }
    public string? Enrollments { get; set; }
}