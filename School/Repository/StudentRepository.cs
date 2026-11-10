using Microsoft.AspNetCore.Mvc;
using SchoolProject.Data;
using SchoolProject.Interfaces;
using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Student>> GetAllStudents()
        {
            throw new NotImplementedException();
        }
        public Task<Student?> GetStudentById(int id)
        {
            throw new NotSupportedException();
        }
        public Task<Student> AddNewStudent(Student student)
        {
            throw new NotSupportedException();

        }
        public Task<Student> UpdateStudent(Student student, int id)
        {
            throw new NotSupportedException();

        }
        public Task<IActionResult> DeleteStudent(int id)
        {
            throw new NotSupportedException();
        }
    }
}
