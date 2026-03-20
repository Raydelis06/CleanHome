using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanHome.Migrations
{
    /// <inheritdoc />
    public partial class CrearServicios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Servicios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Servicios");
        }
    }
}
