namespace SchoolProject.Models.DTOs
{
    public class SubjectDTO
    {
        public int SubId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Content { get; set; }
        public decimal Grade { get; set; }
    }
}
