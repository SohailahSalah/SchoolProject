using SchoolProject.DTOs.Subject;
using SchoolProject.Models;

namespace SchoolProject.Mappers
{
    public static class SubjectMappers
    {
        public static SubjectDTO ToSubjectDTO(this Subject subject)
        {
            return new SubjectDTO
            {
                SubId = subject.SubId,
                Name = subject.Name,
                Content = subject.Content,
                Grade = subject.Grade
            };
        }
    }
}
