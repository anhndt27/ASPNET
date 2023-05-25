using ASPNETBLL.Concrete;
using ASPNETBLL.DTOs.Filter;
using ASPNETBLL.DTOs.StudentQueryDto;
using ASPNETBLL.Interface;
using ASPNETDAL.Context;
using ASPNETDAL.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ASPNETBLL.Services;

public class StudentServices : IStudentServices
{
    private readonly AppDbContext _context;
    public readonly IMapper _mapper;

    public StudentServices(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> AddAsync(StudentDto entity)
    {
        var students = _mapper.Map<Student>(entity);
        var res = _context.Add((object)students);
        await _context.SaveChangesAsync();
        return true;
      
    }

    public async Task<bool> DeleteAsync(StudentDto entity)
    {
        var students = _mapper.Map<Student>(entity);
        var res = _context.Students.Remove(students);
        await _context.SaveChangesAsync();
        return true;
        
    }

    public async Task<IEnumerable<StudentDto>> GetListSortAsync(SortFilterPageOptions options)
    {
        var listService = new ListStudentServices(_context);
        var listStudent = await listService.SortFilterPage(options).ToListAsync();
        return listStudent.ToList();
    }

    public async Task<StudentDto> GetByIdAsync(int? id)
    {
        var res = await _context.Students.FindAsync(id);
        return _mapper.Map<StudentDto>(res);
    }

    public async Task<bool> UpdateAsync(StudentDto entity)
    {
        var students = _mapper.Map<Student>(entity);
        var res = _context.Students.Update(students);
        await _context.SaveChangesAsync();
        return true;
    }
}