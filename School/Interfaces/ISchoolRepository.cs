using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;

namespace SchoolProject.Interfaces
{
    public interface ISchoolRepository
    {
        public Task<List<Student>> GetAllSchools();
        public Task<Student?> GetSchoolById(int id);
        public Task<Student> AddNewSchool(Student student);
        public Task<Student> UpdateSchool(Student student, int id);
        public Task<IActionResult> DeleteSchool(int id);
    }
}
