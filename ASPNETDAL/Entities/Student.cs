using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ASPNETDAL.Entities;

public class Student
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Last name cannot be longer than 30 characters.")]
    [DisplayName("Full Name")]
    public string? StudentName { get; set; }
    
    [Required]
    [DisplayName("Code")]
    [StringLength(10, MinimumLength = 2, ErrorMessage = "Last name cannot be longer than 10 characters.")]
    public string? StudentCode { get; set; }
        

    public virtual ICollection<Enrollment>? Enrollments { get; set; }
}