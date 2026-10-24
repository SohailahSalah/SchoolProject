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
    public class TeacherController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TeacherController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            List<Teacher> teachers = await _context.Teachers.ToListAsync();
            return Ok(teachers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            Teacher teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewTeacher(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return Created();
        }
        [HttpPost("CreateNewTeacherUsingDTO")]
        public async Task<IActionResult> CreateNewTeacher([FromBody] TeacherDTO teacherDTO )
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var teacher = new Teacher
            {
                Name = teacherDTO.Name,
                IsAvailable = teacherDTO.IsAvailable,
                Sessions = teacherDTO.Sessions
            };
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return Ok(teacher);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(Teacher teacher, int id)
        {
            teacher.TeacherId = id;
            bool teacherExists = await _context.Teachers.AnyAsync(s => s.TeacherId == id);
            if (!teacherExists)
            {
                return NotFound();
            }
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
            return Ok(teacher);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            Teacher teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return Ok(teacher);
        }
    }
}
