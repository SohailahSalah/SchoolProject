namespace SchoolProject.Models.DTOs
{
    public class SchoolDTO
    {
        public int SchoolId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; }
        public int NumOfClasses { get; set; }

    }
}