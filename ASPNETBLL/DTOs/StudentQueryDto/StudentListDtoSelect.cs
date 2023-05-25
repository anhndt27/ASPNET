using ASPNETDAL.Entities;

namespace ASPNETBLL.DTOs.StudentQueryDto;

public static class StudentListDtoSelect
{
    public static IQueryable<StudentDto> MapListStudentDto(this IQueryable<Student> students)
    {
        return students.Select(s => new StudentDto
        {
            Id = s.Id,
            Name = s.StudentName,
            Code = s.StudentCode,
            Cource = string.Join(", ", s.Enrollments!.Select(e => e.Course!.Title))
        });
    }
}