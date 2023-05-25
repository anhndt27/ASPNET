using ASPNETBLL.Interface;
using ASPNETDAL.Context;
using ASPNETDAL.Entities;
using AutoMapper;

namespace ASPNETBLL.Services;

public class EnrollmentServices : IEnrollmentServices
{
    private readonly AppDbContext _context;
    public readonly IMapper _mapper;
    public readonly IStudentServices _StudentService;

    public EnrollmentServices(AppDbContext context, IMapper mapper, IStudentServices studentService)
    {
        _context = context;
        _mapper = mapper;
        _StudentService = studentService;
    }

    public async Task<bool> AddStudentToCourse(int couresId, int studentId)
    {
        var entity = new Enrollment
        {
            StudentId = (int)studentId,
            CourseId = (int)couresId
        };
        var res = _context.Enrollments.Add(entity);
        await _context.SaveChangesAsync();
        if (res != null) return true;
        else return false;
    }
}