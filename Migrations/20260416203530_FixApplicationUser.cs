using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanHome.Migrations
{
    /// <inheritdoc />
    public partial class FixApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Clientes",
            //    columns: table => new
            //    {
            //        ClienteId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Estado = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Clientes", x => x.ClienteId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Empleados",
            //    columns: table => new
            //    {
            //        EmpleadoId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Estado = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Empleados", x => x.EmpleadoId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Facturas",
            //    columns: table => new
            //    {
            //        FacturaId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CodigoFactura = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        MontoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        EstadoFactura = table.Column<int>(type: "int", nullable: false),
            //        Estado = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Facturas", x => x.FacturaId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Materiales",
            //    columns: table => new
            //    {
            //        MaterialId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CantidadDisponible = table.Column<int>(type: "int", nullable: false),
            //        Unidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Precio = table.Column<double>(type: "float", nullable: false),
            //        ProveedorId = table.Column<int>(type: "int", nullable: false),
            //        Estado = table.Column<int>(type: "int", nullable: false),
            //        Cantidad = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Materiales", x => x.MaterialId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Propiedades",
            //    columns: table => new
            //    {
            //        PropiedadId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ClienteId = table.Column<int>(type: "int", nullable: false),
            //        TipoPropiedadId = table.Column<int>(type: "int", nullable: false),
            //        Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CantidadHabitaciones = table.Column<int>(type: "int", nullable: false),
            //        TamañoMetrosCuadrados = table.Column<double>(type: "float", nullable: false),
            //        Estado = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Propiedades", x => x.PropiedadId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Proveedores",
            //    columns: table => new
            //    {
            //        ProveedorId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Estado = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Proveedores", x => x.ProveedorId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Servicios",
            //    columns: table => new
            //    {
            //        ServicioId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Precio = table.Column<double>(type: "float", nullable: false),
            //        Duracion = table.Column<int>(type: "int", nullable: false),
            //        Estado = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Servicios", x => x.ServicioId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Solicitudes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ClienteId = table.Column<int>(type: "int", nullable: false),
            //        Descripcion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
            //        Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Estado = table.Column<int>(type: "int", nullable: false),
            //        EstaInactiva = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Solicitudes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TiposPropiedad",
            //    columns: table => new
            //    {
            //        TipoPropiedadId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Estado = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TiposPropiedad", x => x.TipoPropiedadId);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "FacturaDetalles",
            //    columns: table => new
            //    {
            //        FacturaDetalleId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FacturaId = table.Column<int>(type: "int", nullable: false),
            //        MaterialId = table.Column<int>(type: "int", nullable: false),
            //        Cantidad = table.Column<int>(type: "int", nullable: false),
            //        Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_FacturaDetalles", x => x.FacturaDetalleId);
            //        table.ForeignKey(
            //            name: "FK_FacturaDetalles_Facturas_FacturaId",
            //            column: x => x.FacturaId,
            //            principalTable: "Facturas",
            //            principalColumn: "FacturaId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_FacturaDetalles_Materiales_MaterialId",
            //            column: x => x.MaterialId,
            //            principalTable: "Materiales",
            //            principalColumn: "MaterialId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrdenesCompra",
            //    columns: table => new
            //    {
            //        OrdenCompraId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProveedorId = table.Column<int>(type: "int", nullable: false),
            //        Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        Estado = table.Column<int>(type: "int", nullable: false),
            //        EstadoOrden = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrdenesCompra", x => x.OrdenCompraId);
            //        table.ForeignKey(
            //            name: "FK_OrdenesCompra_Proveedores_ProveedorId",
            //            column: x => x.ProveedorId,
            //            principalTable: "Proveedores",
            //            principalColumn: "ProveedorId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "FacturaServicios",
            //    columns: table => new
            //    {
            //        FacturaServicioId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FacturaId = table.Column<int>(type: "int", nullable: false),
            //        ServicioId = table.Column<int>(type: "int", nullable: false),
            //        Cantidad = table.Column<int>(type: "int", nullable: false),
            //        Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_FacturaServicios", x => x.FacturaServicioId);
            //        table.ForeignKey(
            //            name: "FK_FacturaServicios_Facturas_FacturaId",
            //            column: x => x.FacturaId,
            //            principalTable: "Facturas",
            //            principalColumn: "FacturaId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_FacturaServicios_Servicios_ServicioId",
            //            column: x => x.ServicioId,
            //            principalTable: "Servicios",
            //            principalColumn: "ServicioId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrdenesCompraDetalle",
            //    columns: table => new
            //    {
            //        OrdenCompraDetalleId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        OrdenCompraId = table.Column<int>(type: "int", nullable: false),
            //        MaterialId = table.Column<int>(type: "int", nullable: false),
            //        Cantidad = table.Column<int>(type: "int", nullable: false),
            //        Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrdenesCompraDetalle", x => x.OrdenCompraDetalleId);
            //        table.ForeignKey(
            //            name: "FK_OrdenesCompraDetalle_Materiales_MaterialId",
            //            column: x => x.MaterialId,
            //            principalTable: "Materiales",
            //            principalColumn: "MaterialId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_OrdenesCompraDetalle_OrdenesCompra_OrdenCompraId",
            //            column: x => x.OrdenCompraId,
            //            principalTable: "OrdenesCompra",
            //            principalColumn: "OrdenCompraId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.InsertData(
            //    table: "TiposPropiedad",
            //    columns: new[] { "TipoPropiedadId", "Descripcion", "Estado" },
            //    values: new object[,]
            //    {
            //        { 1, "Apartamento", 0 },
            //        { 2, "Casa", 0 },
            //        { 3, "Penthouse", 0 },
            //        { 4, "Duplex", 0 },
            //        { 5, "Villa", 0 },
            //        { 6, "Local Comercial", 0 }
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FacturaDetalles_FacturaId",
            //    table: "FacturaDetalles",
            //    column: "FacturaId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FacturaDetalles_MaterialId",
            //    table: "FacturaDetalles",
            //    column: "MaterialId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FacturaServicios_FacturaId",
            //    table: "FacturaServicios",
            //    column: "FacturaId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FacturaServicios_ServicioId",
            //    table: "FacturaServicios",
            //    column: "ServicioId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrdenesCompra_ProveedorId",
            //    table: "OrdenesCompra",
            //    column: "ProveedorId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrdenesCompraDetalle_MaterialId",
            //    table: "OrdenesCompraDetalle",
            //    column: "MaterialId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrdenesCompraDetalle_OrdenCompraId",
            //    table: "OrdenesCompraDetalle",
            //    column: "OrdenCompraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            //migrationBuilder.DropTable(
            //    name: "Clientes");

            //migrationBuilder.DropTable(
            //    name: "Empleados");

            //migrationBuilder.DropTable(
            //    name: "FacturaDetalles");

            //migrationBuilder.DropTable(
            //    name: "FacturaServicios");

            //migrationBuilder.DropTable(
            //    name: "OrdenesCompraDetalle");

            //migrationBuilder.DropTable(
            //    name: "Propiedades");

            //migrationBuilder.DropTable(
            //    name: "Solicitudes");

            //migrationBuilder.DropTable(
            //    name: "TiposPropiedad");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "Facturas");

            //migrationBuilder.DropTable(
            //    name: "Servicios");

            //migrationBuilder.DropTable(
            //    name: "Materiales");

            //migrationBuilder.DropTable(
            //    name: "OrdenesCompra");

            //migrationBuilder.DropTable(
            //    name: "Proveedores");
        }
    }
}
