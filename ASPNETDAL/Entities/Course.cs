using System.ComponentModel.DataAnnotations;

namespace ASPNETDAL.Entities;

public class Course
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Title { get; set; }
    [Required]
    public double Credits { get; set; }
    public virtual ICollection<Enrollment>? Enrollments { get; set; }
}