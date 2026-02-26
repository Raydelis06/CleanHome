using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanHome.Migrations
{
    /// <inheritdoc />
    public partial class Agrega_Materiales_Estado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Materiales",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Materiales");
        }
    }
}
