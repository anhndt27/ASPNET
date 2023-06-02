using ASPNETBLL.DTOs.Filter;
using ASPNETBLL.DTOs.StudentQueryDto;
using ASPNETBLL.Interface;
using ASPNETDAL.Context;
using ASPNETDAL.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

    public async Task<IEnumerable<StudentDto>> GetListAsync(string sortOrder,string searchString,string currentFilter,int? pageNumber)
    {
        try
        {
            var students = from s in _context.Students.AsNoTracking().MapListStudentDto() select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Name.Contains(searchString)
                                               || s.Code.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "id_desc":
                    students = students.OrderByDescending(s => s.Id);
                    break;
                case "Name": 
                    students = students.OrderBy(s => s.Code);
                    break;
                case "name_desc":
                    students = students.OrderByDescending(s => s.Name);
                    break;
                case "Code":
                    students = students.OrderBy(s => s.Code);
                    break;
                case "code_desc":
                    students = students.OrderByDescending(s => s.Code);
                    break;
                default:
                    students = students.OrderBy(s => s.Id);
                    break;
            }
            /*var listStudent = students.AsNoTracking();
            var res = _mapper.Map<IEnumerable<StudentDto>>(listStudent);*/
            return students;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
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