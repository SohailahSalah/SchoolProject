using SchoolProject.Models.DTOs;

namespace SchoolProject.Models.Mappers
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

