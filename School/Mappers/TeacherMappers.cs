using SchoolProject.DTOs.Teacher;
using SchoolProject.Models;

namespace SchoolProject.Mappers
{
    public static class TeacherMappers
    {
        public static TeacherDTO ToTeacherDTO(this Teacher teacher)
        {
            return new TeacherDTO
            {
                TeacherId = teacher.TeacherId,
                Name = teacher.Name,
                IsAvailable = teacher.IsAvailable,
                Sessions = teacher.Sessions
            };
        }
    }
}

