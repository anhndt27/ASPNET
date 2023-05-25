using System.Collections;

namespace ASPNETBLL.DTOs.CourseQueryDto;

public class CourseDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public double Credits { get; set; }
    public string? Student { get; set; }
    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}