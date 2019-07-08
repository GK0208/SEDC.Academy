using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Academy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    EstimatedTime = table.Column<int>(nullable: false),
                    TimeSpent = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Academy", "Age", "FirstName", "LastName" },
                values: new object[] { 1, 2, 26, "Goce", "Kabov" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Academy", "Age", "FirstName", "LastName" },
                values: new object[] { 2, 3, 28, "Kire", "Davitkov" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "EstimatedTime", "StudentId", "TimeSpent", "Title" },
                values: new object[,]
                {
                    { 1, 55, 1, 22, "JavaScript" },
                    { 2, 65, 1, 33, "EntityFramework" },
                    { 3, 25, 1, 5, "SqlDatabase" },
                    { 4, 25, 2, 22, "SqlDatabase" },
                    { 5, 55, 2, 22, "DataDriven" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StudentId",
                table: "Projects",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
