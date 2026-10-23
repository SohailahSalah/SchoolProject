using SchoolProject.Models.DTOs;

namespace SchoolProject.Models.Mappers
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
