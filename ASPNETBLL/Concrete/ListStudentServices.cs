using ASPNETBLL.DTOs.Filter;
using ASPNETBLL.DTOs.StudentQueryDto;
using ASPNETDAL.Context;
using Microsoft.EntityFrameworkCore;

namespace ASPNETBLL.Concrete;

public class ListStudentServices
{
    private readonly AppDbContext _context;

    public ListStudentServices(AppDbContext context)
    {
        _context = context;
    }

    public IQueryable<StudentDto> SortFilterPage(SortFilterPageOptions options)
    {
        var studentQuery = _context.Students
            .AsNoTracking()
            .MapListStudentDto()
            .OrderStudentBy(options.OrderByOptions)
            .FilterBooksBy(options.ListDtoFilterBy,options.FilterValue);
        options.SetupRestOfDto(studentQuery);
        return studentQuery.Page(options.PageNum - 1, options.PageSize);
    }
}