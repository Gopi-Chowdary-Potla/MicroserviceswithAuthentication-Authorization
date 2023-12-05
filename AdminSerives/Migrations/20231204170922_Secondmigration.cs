using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminSerives.Migrations
{
    public partial class Secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Autoid", "Name", "Salary" },
                values: new object[] { 1, "Srinu", "10000" });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Autoid", "Name", "Salary" },
                values: new object[] { 2, "Gopi", "20000" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Autoid",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Autoid",
                keyValue: 2);
        }
    }
}
