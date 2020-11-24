using Microsoft.EntityFrameworkCore.Migrations;

namespace xCourse.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Degree",
                columns: table => new
                {
                    DegreeAbbriviation = table.Column<string>(nullable: false),
                    Major = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degree", x => x.DegreeAbbriviation);
                });

            migrationBuilder.CreateTable(
                name: "FlowchartModel",
                columns: table => new
                {
                    CourseCodeAbbriviation = table.Column<string>(nullable: false),
                    DegreeAbbriviation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowchartModel", x => x.CourseCodeAbbriviation);
                    table.ForeignKey(
                        name: "FK_FlowchartModel_Degree_DegreeAbbriviation",
                        column: x => x.DegreeAbbriviation,
                        principalTable: "Degree",
                        principalColumn: "DegreeAbbriviation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeAbbriviation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Semester_Degree_DegreeAbbriviation",
                        column: x => x.DegreeAbbriviation,
                        principalTable: "Degree",
                        principalColumn: "DegreeAbbriviation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseCodeAbbriviation = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Hours = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CourseID = table.Column<int>(nullable: true),
                    SemesterID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Course_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Course_Semester_SemesterID",
                        column: x => x.SemesterID,
                        principalTable: "Semester",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseID",
                table: "Course",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_SemesterID",
                table: "Course",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_FlowchartModel_DegreeAbbriviation",
                table: "FlowchartModel",
                column: "DegreeAbbriviation");

            migrationBuilder.CreateIndex(
                name: "IX_Semester_DegreeAbbriviation",
                table: "Semester",
                column: "DegreeAbbriviation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "FlowchartModel");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.DropTable(
                name: "Degree");
        }
    }
}
