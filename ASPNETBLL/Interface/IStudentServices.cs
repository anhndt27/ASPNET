using ASPNETBLL.DTOs.Filter;
using ASPNETBLL.DTOs.StudentQueryDto;
using ASPNETDAL.Entities;

namespace ASPNETBLL.Interface;

public interface IStudentServices
{
    Task<IEnumerable<StudentDto>> GetListAsync(string sortOrder,string searchString,string currentFilter,int? pageNumber);
    Task<StudentDto> GetByIdAsync(int? id);
    Task<bool> AddAsync(StudentDto entity);

    Task<bool> UpdateAsync(StudentDto entity);

    Task<bool> DeleteAsync(StudentDto entity);
}