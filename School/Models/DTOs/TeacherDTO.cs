namespace SchoolProject.Models.DTOs
{
    public class TeacherDTO
    {
        public int TeacherId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public int Sessions { get; set; }

    }
}
