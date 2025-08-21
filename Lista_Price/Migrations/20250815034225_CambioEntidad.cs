using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lista_Price.Migrations
{
    /// <inheritdoc />
    public partial class CambioEntidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Users",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "UserEmail");
        }
    }
}
