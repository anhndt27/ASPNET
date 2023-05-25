using ASPNETBLL.DTOs.CourseQueryDto;

namespace ASPNETBLL.Interface;

public interface ICourseServices
{
    Task<IEnumerable<CourseDto>> GetListCourseStudentAsync();
    Task<IEnumerable<CourseDto>> GetByIdAsync(int? id);
    Task<bool> AddAsync(CourseRequestDto entity);
    Task<bool> UpdateAsync(CourseRequestDto entity);
    Task<CourseRequestDto> FindById(int? id);
    Task<bool> DeleteAsync(CourseRequestDto entity);
}