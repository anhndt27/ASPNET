using ASPNETDAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASPNETDAL.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Enrollment>()
            .HasKey(e => new { e.StudentId, e.CourseId });

        builder.Entity<Enrollment>()
            .HasOne(e => e.Student)
            .WithMany(e => e.Enrollments)
            .HasForeignKey(e => e.StudentId);

        builder.Entity<Enrollment>()
            .HasOne(e => e.Course)
            .WithMany(e => e.Enrollments)
            .HasForeignKey(e => e.CourseId);
    }


    public DbSet<Student> Students { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Course> Courses { get; set; }
}