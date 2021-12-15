using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Primary_School.Migrations
{
    public partial class setEmployeeToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(nullable: false),
                    empName = table.Column<string>(nullable: false),
                    empEmail = table.Column<string>(nullable: false),
                    empPhoneNumber = table.Column<string>(nullable: false),
                    empSalary = table.Column<int>(nullable: false),
                    userType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
