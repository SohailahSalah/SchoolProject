using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class Subject
    {
        [Key]
        public int SubId { get; set; }
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; }
        [Column(TypeName ="decimal(4,1)")]
        public decimal Grade { get; set; }
        public ICollection<Teacher> Teachers { get; set; } = new HashSet<Teacher>();
    }
}
