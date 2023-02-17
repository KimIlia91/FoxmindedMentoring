using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HogwartsUniversity.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COURSES",
                columns: table => new
                {
                    COURSEID = table.Column<int>(name: "COURSE_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COURSES", x => x.COURSEID);
                });

            migrationBuilder.CreateTable(
                name: "GROUPS",
                columns: table => new
                {
                    GROUPID = table.Column<int>(name: "GROUP_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COURSEID = table.Column<int>(name: "COURSE_ID", type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GROUPS", x => x.GROUPID);
                    table.ForeignKey(
                        name: "FK_GROUPS_COURSES_COURSE_ID",
                        column: x => x.COURSEID,
                        principalTable: "COURSES",
                        principalColumn: "COURSE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "STUDENTS",
                columns: table => new
                {
                    STUDENTID = table.Column<int>(name: "STUDENT_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GROUPID = table.Column<int>(name: "GROUP_ID", type: "int", nullable: false),
                    FIRSTNAME = table.Column<string>(name: "FIRST_NAME", type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LASTNAME = table.Column<string>(name: "LAST_NAME", type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENTS", x => x.STUDENTID);
                    table.ForeignKey(
                        name: "FK_STUDENTS_GROUPS_GROUP_ID",
                        column: x => x.GROUPID,
                        principalTable: "GROUPS",
                        principalColumn: "GROUP_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GROUPS_COURSE_ID",
                table: "GROUPS",
                column: "COURSE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENTS_GROUP_ID",
                table: "STUDENTS",
                column: "GROUP_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STUDENTS");

            migrationBuilder.DropTable(
                name: "GROUPS");

            migrationBuilder.DropTable(
                name: "COURSES");
        }
    }
}
