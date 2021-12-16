using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Primary_School.Migrations
{
    public partial class addStudentToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(nullable: false),
                    stdName = table.Column<string>(nullable: false),
                    stdPassword = table.Column<string>(nullable: false),
                    stdEmail = table.Column<string>(nullable: false),
                    stdPhone = table.Column<string>(nullable: false),
                    stdAddress = table.Column<string>(nullable: false),
                    stdSection = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
