using ASPNETBLL.DTOs.Filter;
using ASPNETBLL.DTOs.StudentQueryDto;
using ASPNETBLL.Interface;
using ASPNETBLL.Services;
using ASPNETDAL.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNETapiapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        public readonly IStudentServices _studentService;

        public StudentApiController(IStudentServices studentServices)
        {
            _studentService = studentServices;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public async Task<Paging<StudentDto>> GetSortStudent(string? sortOrder, string? searchString, string? currentFilter, int? pageNumber)
        {
            try
            { 
                /*ViewData["CurrentSort"] = sortOrder;
                ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
                ViewData["NameSortParm"] = sortOrder == "Name" ? "name_desc" : "Code";
                ViewData["CodeSortParm"] = sortOrder == "Code" ? "code_desc" : "Code";*/
                sortOrder = "Id";
                if (searchString != null)
                {
                    pageNumber = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                //ViewData["CurrentFilter"] = searchString;
                //var listService = new ListStudentServices(_context);
                var res = await _studentService.GetListAsync(sortOrder, searchString, currentFilter, pageNumber);
                int pageSize = 5;
                var resault = await Paging<StudentDto>.CreateAsync(res, pageNumber ?? 1, pageSize);
                return resault;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<StudentDto> GetDetails(int id)
        {
            var UserProfile = await _studentService.GetByIdAsync(id);
            return UserProfile;
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task Create([FromBody] StudentDto entity)
        {
            try
            {
                var res = await _studentService.AddAsync(entity);
                if (res)
                {
                    
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",
                    $"Unable to save changes. Student Code is already exist!");
                Console.WriteLine(ex);
            }
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async Task Update(int id, [FromBody] StudentDto entity)
        {
            var res = await _studentService.GetByIdAsync(id);
            if (res != null)
            {
                entity.Id = id; 
                _studentService.UpdateAsync(entity);
            }
            /*entity.Id = id;
            await _studentService.UpdateAsync(entity);*/
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            //var res = await _studentService.GetByIdAsync(id);
            var studentdto = new StudentDto();
            studentdto.Id = id;
            await _studentService.DeleteAsync(studentdto);
        }
    }
}
