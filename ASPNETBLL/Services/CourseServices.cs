using ASPNETBLL.DTOs.CourseQueryDto;
using ASPNETBLL.Interface;
using ASPNETDAL.Context;
using ASPNETDAL.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ASPNETBLL.Services;

public class CourseServices : ICourseServices
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CourseServices(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> AddAsync(CourseRequestDto entity)
    {
        try
        {
            var course = _mapper.Map<Course>(entity);
            var res = _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            if (res != null)
            {
                return true;
            }

            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public Task<IEnumerable<CourseDto>> GetListCourseStudentAsync()
    {
        try
        {
            var res = _context.Courses.AsNoTracking().MapListCouresDto();
            return Task.FromResult<IEnumerable<CourseDto>>(res.ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<CourseDto>> GetByIdAsync(int? id)
    {
        try
        {
            var res = _context.Courses.AsNoTracking().MapListCouresDto();
            return res.Where(e => e.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<bool> UpdateAsync(CourseRequestDto entity)
    {
        try
        {
            var course = _mapper.Map<Course>(entity);
            var res = _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            if (res != null) return true;
            else return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<CourseRequestDto> FindById(int? id)
    {
        try
        {
            var res = await _context.Courses.FindAsync(id);
            var courseDto = _mapper.Map<CourseRequestDto>(res);
            return courseDto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> DeleteAsync(CourseRequestDto entity)
    {
        try
        {
            var course = _mapper.Map<Course>(entity);
            var res = _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            if (res != null) return true;
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}