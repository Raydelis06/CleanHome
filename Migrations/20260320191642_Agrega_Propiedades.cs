using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanHome.Migrations
{
    /// <inheritdoc />
    public partial class Agrega_Propiedades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Propiedades",
                columns: table => new
                {
                    PropiedadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    TipoPropiedadId = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadHabitaciones = table.Column<int>(type: "int", nullable: false),
                    TamañoMetrosCuadrados = table.Column<double>(type: "float", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propiedades", x => x.PropiedadId);
                });

            migrationBuilder.CreateTable(
                name: "TiposPropiedad",
                columns: table => new
                {
                    TipoPropiedadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPropiedad", x => x.TipoPropiedadId);
                });

            migrationBuilder.InsertData(
                table: "TiposPropiedad",
                columns: new[] { "TipoPropiedadId", "Descripcion", "Estado" },
                values: new object[,]
                {
                    { 1, "Apartamento", 0 },
                    { 2, "Casa", 0 },
                    { 3, "Penthouse", 0 },
                    { 4, "Duplex", 0 },
                    { 5, "Villa", 0 },
                    { 6, "Local Comercial", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Propiedades");

            migrationBuilder.DropTable(
                name: "TiposPropiedad");
        }
    }
}
