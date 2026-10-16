using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "SchoolId", "Address", "Name", "NumOfClasses" },
                values: new object[,]
                {
                    { 1, "El-Hejaz", "Ebrahim El-Jaafary", 30 },
                    { 2, "Al-Horreya Street", "Talaat Harb High School", 24 },
                    { 3, "Nile Corniche", "Al-Andalus Modern School", 36 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "GradeLevel", "IsMale", "Name" },
                values: new object[,]
                {
                    { 1, 3, true, "Ali" },
                    { 2, 2, false, "Fatma" },
                    { 3, 1, true, "Omar" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubId", "Content", "Grade", "Name" },
                values: new object[,]
                {
                    { 1, "Algebra, calculus, and analytical geometry fundamentals", 150m, "Math" },
                    { 2, "Mechanics, thermodynamics, and electricity basics", 100m, "Physics" },
                    { 3, "Introduction to programming logic and C# fundamentals", 200m, "Computer Science" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "IsAvailable", "Name", "SchoolId", "Sessions", "SubId", "SubjectSubId" },
                values: new object[,]
                {
                    { 1, true, "Ahmed", 1, 8, 1, null },
                    { 2, true, "Mohamed", 2, 10, 3, null },
                    { 3, false, "Mona", 3, 6, 2, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: 3);
        }
    }
}
