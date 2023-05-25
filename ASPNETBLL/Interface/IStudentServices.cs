using ASPNETBLL.DTOs.Filter;
using ASPNETBLL.DTOs.StudentQueryDto;

namespace ASPNETBLL.Interface;

public interface IStudentServices
{
    Task<IEnumerable<StudentDto>> GetListSortAsync(SortFilterPageOptions options);
    Task<StudentDto> GetByIdAsync(int? id);
    Task<bool> AddAsync(StudentDto entity);

    Task<bool> UpdateAsync(StudentDto entity);

    Task<bool> DeleteAsync(StudentDto entity);
}