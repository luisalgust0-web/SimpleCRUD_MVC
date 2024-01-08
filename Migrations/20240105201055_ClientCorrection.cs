using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCRUD_MVC.Migrations
{
    /// <inheritdoc />
    public partial class ClientCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Client",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Client",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Client",
                newName: "Name");
        }
    }
}
