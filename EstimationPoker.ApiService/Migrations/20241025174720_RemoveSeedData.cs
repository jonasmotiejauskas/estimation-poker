using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstimationPoker.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role", "Salt" },
                values: new object[] { 1, "john.doe@gmail.com", "John Doe", new byte[0], "Admin", new byte[0] });
        }
    }
}
