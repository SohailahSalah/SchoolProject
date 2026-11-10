using Microsoft.AspNetCore.Mvc;
using SchoolProject.Data;
using SchoolProject.Interfaces;
using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly AppDbContext _context;
        public SchoolRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Student>> GetAllSchool()
        {
            throw new NotImplementedException();
        }
        public Task<Student?> GetSchoolById(int id)
        {
            throw new NotSupportedException();
        }
        public Task<Student> AddNewSchool(Student student)
        {
            throw new NotSupportedException();

        }
        public Task<Student> UpdateSchool(Student student, int id)
        {
            throw new NotSupportedException();

        }
        public Task<IActionResult> DeleteSchool(int id)
        {
            throw new NotSupportedException();
        }
    }
}
