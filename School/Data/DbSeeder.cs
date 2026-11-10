using Microsoft.EntityFrameworkCore;
using SchoolProject.Data;
using SchoolProject.Models;

namespace SchoolProject.Data
{
    public static class DbSeeder
    {
        private static readonly string[] FirstNames = { "Ahmed", "Ali", "Sara", "Mona", "Omar", "Youssef", "Nour", "Mariam" };
        private static readonly string[] LastNames = { "Salah", "Hassan", "Ibrahim", "Khalil", "Mahmoud", "Tarek" };
        private static readonly string[] SubjectNames = { "Mathematics", "English", "Physics", "Chemistry", "Computer Science", "History" };
        private static readonly string[] Governorates = { "Cairo", "Giza", "Alexandria", "Mansoura", "Tanta" };

        public static async Task SeedAsync(AppDbContext context, IConfiguration configuration, ILogger logger)
        {
            var section = configuration.GetSection("SeedData");
            if (!section.GetValue("Enabled", false))
                return;

            // التأكد إن مفيش مَيجريشنز معلقة عشان منعملش Insert في جداول مش جاهزة
            if ((await context.Database.GetPendingMigrationsAsync()).Any())
            {
                logger.LogWarning("Seeding skipped: Pending migrations found. Run Update-Database first.");
                return;
            }

            var target = section.GetValue("RecordsPerTable", 50) * section.GetValue("Multiplier", 1);
            var random = new Random(42);

            // ================= 1. Schools =================
            var schoolCount = await context.Schools.CountAsync();
            if (schoolCount < target)
            {
                var newSchools = new List<School>();
                for (var i = schoolCount + 1; i <= target; i++)
                {
                    newSchools.Add(new School
                    {
                        Name = $"Elite School #{i}",
                        Address = $"{Governorates[random.Next(Governorates.Length)]}, Street {i}"
                    });
                }

                await context.Schools.AddRangeAsync(newSchools);
                await context.SaveChangesAsync();
                logger.LogInformation("Seeded {Count} schools", newSchools.Count);
            }

            // سحب الـ Ids الحقيقية للمدارس لاستخدامها كـ Foreign Keys
            var schoolIds = await context.Schools.Select(s => s.SchoolId).ToListAsync();

            // ================= 2. Subjects =================
            var subjectCount = await context.Subjects.CountAsync();
            if (subjectCount < SubjectNames.Length)
            {
                var existingSubjectNames = await context.Subjects.Select(s => s.Name).ToHashSetAsync();
                var newSubjects = SubjectNames
                    .Where(name => !existingSubjectNames.Contains(name))
                    .Select(name => new Subject { Name = name })
                    .ToList();

                if (newSubjects.Any())
                {
                    await context.Subjects.AddRangeAsync(newSubjects);
                    await context.SaveChangesAsync();
                    logger.LogInformation("Seeded {Count} subjects", newSubjects.Count);
                }
            }

            // ================= 3. Students =================
            var studentCount = await context.Students.CountAsync();
            if (studentCount < target && schoolIds.Any())
            {
                var newStudents = new List<Student>();
                for (var i = studentCount + 1; i <= target; i++)
                {
                    var fName = FirstNames[random.Next(FirstNames.Length)];
                    var lName = LastNames[random.Next(LastNames.Length)];

                    newStudents.Add(new Student
                    {
                        Name = $"{fName} {lName}",
                        //SchoolId = schoolIds[random.Next(schoolIds.Count)]
                    });
                }

                await context.Students.AddRangeAsync(newStudents);
                await context.SaveChangesAsync();
                logger.LogInformation("Seeded {Count} students", newStudents.Count);
            }
        }
    }
}