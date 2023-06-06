using ASPNETBLL.DTOs.CourseQueryDto;
using ASPNETBLL.DTOs.StudentQueryDto;
using ASPNETBLL.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNETapiapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseApiController : ControllerBase
    {
        public readonly ICourseServices _courseServices;

        public CourseApiController(ICourseServices courseServices)
        {
            _courseServices = courseServices;
        }
        // GET: api/<CourseController>
        [HttpGet]
        public async Task<IEnumerable<CourseDto>> GetAll()
        {
            var courseList = await _courseServices.GetListCourseStudentAsync();
            return courseList;
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<CourseDto>> GetById(int id)
        {
            var res =await _courseServices.GetByIdAsync(id);
            return res;
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<bool> Post([FromBody] CourseRequestDto entity)
        {
            var res = await _courseServices.AddAsync(entity);
            return res;
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public async Task Update(int id, [FromBody] CourseRequestDto entity)
        {
            var res = await _courseServices.FindById(id);
            entity.Id = id; _courseServices.UpdateAsync(entity);
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {        
            var coursedto = new CourseRequestDto();
            coursedto.Id = id;
            await _courseServices.DeleteAsync(coursedto);
        }
    }
}