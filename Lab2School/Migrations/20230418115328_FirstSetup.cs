using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2School.Migrations
{
    /// <inheritdoc />
    public partial class FirstSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Points = table.Column<int>(type: "int", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeacherLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeacherEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherID);
                });

            migrationBuilder.CreateTable(
                name: "CoursesLists",
                columns: table => new
                {
                    CourseListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_TeacherID = table.Column<int>(type: "int", nullable: false),
                    FK_StudentID = table.Column<int>(type: "int", nullable: false),
                    FK_CourseID = table.Column<int>(type: "int", nullable: false),
                    FK_ClassID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesLists", x => x.CourseListID);
                    table.ForeignKey(
                        name: "FK_CoursesLists_Classes_FK_ClassID",
                        column: x => x.FK_ClassID,
                        principalTable: "Classes",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesLists_Courses_FK_CourseID",
                        column: x => x.FK_CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesLists_Students_FK_StudentID",
                        column: x => x.FK_StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesLists_Teachers_FK_TeacherID",
                        column: x => x.FK_TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursesLists_FK_ClassID",
                table: "CoursesLists",
                column: "FK_ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesLists_FK_CourseID",
                table: "CoursesLists",
                column: "FK_CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesLists_FK_StudentID",
                table: "CoursesLists",
                column: "FK_StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesLists_FK_TeacherID",
                table: "CoursesLists",
                column: "FK_TeacherID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursesLists");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
