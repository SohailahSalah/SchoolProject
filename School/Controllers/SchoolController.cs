using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.NativeInterop;
using SchoolProject.Data;
using SchoolProject.Models;
using System.Collections;

namespace SchoolProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SchoolController(AppDbContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSchools()
        {
            List<School> schools = await _context.Schools.ToListAsync();
             return Ok(schools);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchoolByID(int id)
        {
            School school = await _context.Schools.FindAsync(id);
            if (school == null)
            {
                return NotFound();
            }
            return Ok(school);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewSchool(School school)
        {
            await _context.Schools.AddAsync(school);
            await _context.SaveChangesAsync();
            return Created();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchool(int id, School newSchool)
        {            
            _context.Schools.Update(newSchool);
            await _context.SaveChangesAsync();
            return Ok(newSchool);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            //Hard Delete
            School school = await _context.Schools.FindAsync(id);
            if(school == null)
            {  
                return NotFound();
            }
            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();
            return Ok(school);
            //SoftDelete
        //    School school = await _context.Schools.FindAsync(id);
        //    if(school == null)
        //    {
        //        return BadRequest($"There are no School with id = {id}");
        //    }
        //    school.IsDeleted = true;
        //    await _context.SaveChangesAsync();
        //    return Ok(school);
        }
    }
}
