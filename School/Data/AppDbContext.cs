using Microsoft.EntityFrameworkCore;
using SchoolProject.Models;

namespace SchoolProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<School>().HasData(
                new School()
                {
                    SchoolId = 1,
                    Address = "El-Hejaz",
                    Name = "Ebrahim El-Jaafary",
                    NumOfClasses = 30
                },
                new School()
                {
                    SchoolId = 2,
                    Address = "Al-Horreya Street",
                    Name = "Talaat Harb High School",
                    NumOfClasses = 24
                },
                new School()
                {
                    SchoolId = 3,
                    Address = "Nile Corniche",
                    Name = "Al-Andalus Modern School",
                    NumOfClasses = 36
                }
            );
            builder.Entity<Student>().HasData(
                new Student()
                {
                    StudentId = 1,
                    Name = "Ali",
                    GradeLevel = 3,
                    IsMale = true,
                },
                new Student()
                {
                    StudentId = 2,
                    Name = "Fatma",
                    GradeLevel = 2,
                    IsMale = false,
                },
                new Student()
                {
                    StudentId = 3,
                    Name = "Omar",
                    GradeLevel = 1,
                    IsMale = true,
                }
            );
            builder.Entity<Subject>().HasData(
                new Subject()
                {
                    SubId = 1,
                    Name = "Math",
                    Content = "Algebra, calculus, and analytical geometry fundamentals",
                    Grade = 150
                },
                new Subject()
                {
                    SubId = 2,
                    Name = "Physics",
                    Content = "Mechanics, thermodynamics, and electricity basics",
                    Grade = 100
                },
                new Subject()
                {
                    SubId = 3,
                    Name = "Computer Science",
                    Content = "Introduction to programming logic and C# fundamentals",
                    Grade = 200
                }
            );
            builder.Entity<Teacher>().HasData(
                new Teacher()
                {
                    TeacherId = 1,
                    Name = "Ahmed",
                    IsAvailable = true,
                    Sessions = 8,
                    SchoolId = 1,
                    SubId = 1
                },
                new Teacher()
                {
                    TeacherId = 2,
                    Name = "Mohamed",
                    IsAvailable = true,
                    Sessions = 10,
                    SchoolId = 2,
                    SubId = 3
                },
                new Teacher()
                {
                    TeacherId = 3,
                    Name = "Mona",
                    IsAvailable = false,
                    Sessions = 6,
                    SchoolId = 3,
                    SubId = 2
                }
            );
        }
    }
}
