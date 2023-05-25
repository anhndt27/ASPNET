using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ASPNETDAL.Entities;

public class User :  IdentityUser
{
    [Required]
    public string? Name { get; set; }
    public byte[]? ProfilePicture { get; set; }
}