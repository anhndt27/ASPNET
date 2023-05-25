namespace ASPNETBLL.DTOs.CourseQueryDto;

public class CourseRequestDto
{
    public int ID { get; set; }
    public string Title { get; set; }
    public double Credits { get; set; }
    public string? Enrollments { get; set; }
}