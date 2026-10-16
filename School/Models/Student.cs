using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set;  }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        public int GradeLevel { get; set; }
        public bool? IsMale { get; set; }
    }
}
