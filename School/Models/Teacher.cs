using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        [Range(0,10)]
        public int Sessions { get; set; }
        [Required]
        public Subject Subject { get; }
        [ForeignKey(nameof(Subject))]
        public int SubId { get; set; }
        [Required]
        public School School { get;}
        [ForeignKey(nameof(School))]
        public int SchoolId { get; set; }
    }
}
