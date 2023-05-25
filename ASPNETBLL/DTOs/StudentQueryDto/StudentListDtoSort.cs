using System.ComponentModel.DataAnnotations;

namespace ASPNETBLL.DTOs.StudentQueryDto;

public enum OrderByOptions
{
    [Display(Name = "sort by...")] SimpleOrder = 0,
    [Display(Name = "Votes ↑")] ByVotes,
    
    
}

public static class StudentListDTOSort
{
    public static IQueryable<StudentDto> OrderStudentBy(this IQueryable<StudentDto> _students, OrderByOptions options)
    {
        switch (options)
        {
            case OrderByOptions.SimpleOrder:
                return _students.OrderByDescending(x => x.Id);
            default:
                throw new ArgumentOutOfRangeException(
                    nameof(options), options, null);
        }
    }
}