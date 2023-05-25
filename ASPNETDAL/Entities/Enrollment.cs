namespace ASPNETDAL.Entities;

public enum Grade
{
    A,
    B,
    C,
    D
}

public class Enrollment
{
    public string? Grade { get; set; }
    public int CourseId { get; set; }
    public int StudentId { get; set; }
    public virtual Course? Course { get; set; }
    public virtual Student? Student { get; set; }
}