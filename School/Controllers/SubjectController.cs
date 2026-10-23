using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data;
using SchoolProject.Models;

namespace SchoolProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SubjectController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSubjects()
        {
            List<Subject> subject = await _context.Subjects.ToListAsync();
            return Ok(subject);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectByID(int id)
        {
            Subject subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewSubject(Subject subject) 
        {
            await _context.AddAsync(subject);
            await _context.SaveChangesAsync();
            return Ok(subject);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(Subject NewSubject, int id)
        {
            _context.Subjects.Update(NewSubject);
            await _context.SaveChangesAsync();
            return Ok(NewSubject);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            Subject subject = _context.Subjects.Find(id);
            if (subject == null)
            {
                return NotFound();
            }
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return Ok(subject);
        }
    }
}
