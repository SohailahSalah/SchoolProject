using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class School
    {
        [Key]
        public int SchoolId { get; set; }
        public string Name { get; set; } = string.Empty;
        [MaxLength(100)]
        [Required]
        public string Address { get; set; }
        public int NumOfClasses { get; set; }
        public ICollection<Teacher> Teachers { get; set; } = new HashSet<Teacher>();
    }
}
