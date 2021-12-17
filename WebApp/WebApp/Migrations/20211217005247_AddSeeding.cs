using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class AddSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsNumber", "Name" },
                values: new object[] { 15, true, "count" });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsNumber", "Name" },
                values: new object[] { 16, true, "start" });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsNumber", "Name" },
                values: new object[] { 17, true, "end" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 17);
        }
    }
}
