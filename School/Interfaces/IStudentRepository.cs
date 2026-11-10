using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;

namespace SchoolProject.Interfaces
{
    public interface IStudentRepository
    {
        public Task<List<Student>> GetAllStudents();
        public Task<Student?> GetStudentById(int id);
        public Task<Student> AddNewStudent(Student student);
        public Task<Student> UpdateStudent(Student student, int id);
        public Task<IActionResult> DeleteStudent(int id);
    }
}
