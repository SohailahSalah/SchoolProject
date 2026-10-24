using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data;
using SchoolProject.Models;
using SchoolProject.Models.DTOs;

namespace SchoolProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;
        public StudentController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            List<Student> students = await _context.Students.ToListAsync();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            Student student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewStudent(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }
        [HttpPost("CreateNewStudentUsingDTO")]
        public async Task<IActionResult> CraeteNewStydent([FromBody] StudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var student = new Student
            {
                Name = studentDTO.Name,
                GradeLevel = studentDTO.GradeLevel,
                IsMale = studentDTO.IsMale
            };
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(Student student,int id)
        {
            student.StudentId = id;
            bool studentExists = await _context.Students.AnyAsync(s => s.StudentId == id);
            if (!studentExists)
            {
                return NotFound(); 
            }
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            Student student = await _context.Students.FindAsync(id);
            if(student == null)
            {
                return NotFound();
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }
    }
}
