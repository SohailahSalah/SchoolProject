using SchoolProject.Models.DTOs;
using SchoolProject.Models.Mappers;

namespace SchoolProject.Models.Mappers
{
    public static class SchoolMappper
    {
        public static SchoolDTO ToSchoolDTO(this School school)
        {
            return new SchoolDTO
            {
                SchoolId = school.SchoolId,
                Name = school.Name,
                Address = school.Address,
                NumOfClasses = school.NumOfClasses
            };
        }
    }
}
