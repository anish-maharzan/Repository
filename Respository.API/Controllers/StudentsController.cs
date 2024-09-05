using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Respository.API.Models.Domain;
using Respository.API.Models.DTO;
using Respository.API.Services.Abstraction;

namespace Respository.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;

        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            this.studentService = studentService;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var studentList = await studentService.GetAllAsync();

            return Ok(mapper.Map<List<StudentDTO>>(studentList));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var student = await studentService.GetByIdAsync(id);
            
            if (student == null)
                return NotFound();
            
            return Ok(mapper.Map<StudentDTO>(student));
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentDTO dto)
        {
            var student = mapper.Map<Student>(dto);

            student = await studentService.AddAsync(student);

            var studentDto = mapper.Map<StudentDTO>(student);

            return CreatedAtAction(nameof(GetStudentById), new { id = studentDto.StudentID }, studentDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] int id, StudentDTO dto)
        {
            var student = mapper.Map<Student>(dto);

            student = await studentService.UpdateAsync(id, student);

            if(student == null)
                return NotFound();

            return Ok(mapper.Map<StudentDTO>(student));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteStudent([FromBody]  int id)
        {
            var student = await studentService.DeleteAsync(id);

            if (student == null)
                return NotFound();

            return Ok(mapper.Map<StudentDTO>(student));
        }
    }
}
