using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanHome.Migrations
{
    /// <inheritdoc />
    public partial class SiembraRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                // Nota que ahora incluimos explícitamente el ConcurrencyStamp
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    {
                        "a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d",
                        "376dec87-a55e-476d-b561-3e5b35d5e7c9", // Valor fijo 1
                        "Admin",
                        "ADMIN"
                    },
                    {
                        "b2c3d4e5-f6a7-4b6c-9d0e-1f2a3b4c5d6e",
                        "8e426c7f-84b3-46f3-a43e-0ea60ca7e639", // Valor fijo 2
                        "Empleado",
                        "EMPLEADO"
                    }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2c3d4e5-f6a7-4b6c-9d0e-1f2a3b4c5d6e");
        }
    }
}
