using System.ComponentModel.DataAnnotations;
namespace SchoolProject.DTOs.School
{
    public class SchoolRequestDTO
    {
        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "School Name must be at least 3 characters")]
        // \s* في الأطراف: بنسمح بمسافات حوالين الرمز لأن الـ Mapper بيعمل Trim + ToUpper
        [RegularExpression(@"^\s*[A-Za-z0-9.\-]+\s*$", ErrorMessage = "School name can contain only letters, digits, dots, or hyphens")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(280, MinimumLength = 2, ErrorMessage = "Address must be 2-280 characters")]
        public string Address { get; set; } = string.Empty;

        // typeof(decimal) لأن الـ attribute مش بيقبل decimal كـ constant
        [Range(3 , 50)]
        public int NumOfClasses { get; set; }
    }
}
