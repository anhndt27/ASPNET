using System.ComponentModel.DataAnnotations;

namespace ASPNETBLL.DTOs.StudentQueryDto;


public enum StudentListDtoFilterBy
{
    [Display(Name = "All")]
    NoFilter = 0,
    [Display(Name = "By Votes...")]
    ByVotes,
 
}
public static class StudentListDTOfilter
{
    public static IQueryable<StudentDto> FilterBooksBy(this IQueryable<StudentDto> students, StudentListDtoFilterBy listDtoFilterBy,
        string filterValue)
    {
        if (string.IsNullOrEmpty(filterValue)) return students;
        switch (listDtoFilterBy)
        {
            case StudentListDtoFilterBy.NoFilter 
                : return students;
            default:
                throw new ArgumentOutOfRangeException(nameof(listDtoFilterBy), listDtoFilterBy, null);
        }
    }

}