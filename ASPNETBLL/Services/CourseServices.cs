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
            var course = _mapper.Map<Course>(entity);
            var res = _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            if (res != null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get All Course and student
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<CourseDto>> GetListCourseStudentAsync()
        {
            var res = _context.Courses.AsNoTracking().MapListCouresDto();
            return res.ToList();
        }

        public async Task<IEnumerable<CourseDto>> GetByIdAsync(int? id)
        {
            var res = _context.Courses.AsNoTracking().MapListCouresDto();

            /*.Where(e => e.ID == id);*/
            return res.Where(e => e.Id == id);
        }

        public async Task<bool> UpdateAsync(CourseRequestDto entity)
        {
            var course = _mapper.Map<Course>(entity);
            var res = _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            if (res != null) return true;
            else return false;
        }

        public async Task<CourseRequestDto> FindById(int? id)
        {
            var res = await _context.Courses.FindAsync(id);
            return _mapper.Map<CourseRequestDto>(res);
        }

        public async Task<bool> DeleteAsync(CourseRequestDto entity)
        {
            var course = _mapper.Map<Course>(entity);
            var res = _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            if (res != null) return true;
            return false;
        }
}