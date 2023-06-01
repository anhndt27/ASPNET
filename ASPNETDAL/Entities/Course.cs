using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ASPNETDAL.Entities;

public class Course
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string? Title { get; set; }
    [Required]
    public double Credits { get; set; }
    public virtual ICollection<Enrollment>? Enrollments { get; set; }
}