using SchoolProject.Models.DTOs;

namespace SchoolProject.Models.Mappers
{
    public static class StudentMappers
    {
        public static StudentDTO ToStudentDTO(this Student student)
        {
            return new StudentDTO
            {
                StudentId = student.StudentId,
                Name = student.Name,
                GradeLevel = student.GradeLevel,
                IsMale = student.IsMale
            };
        }
    }
}
