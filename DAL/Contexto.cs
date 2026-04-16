using CleanHome.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanHome.DAL
{
    public class Contexto : IdentityDbContext<ApplicationUser>
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        public DbSet<OrdenCompra> OrdenesCompra { get; set; }
        public DbSet<OrdenCompraDetalle> OrdenesCompraDetalle { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Materiales> Materiales { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<Propiedades> Propiedades { get; set; }
        public DbSet<TiposPropiedad> TiposPropiedad { get; set; }
        public DbSet<Facturas> Facturas { get; set; }
        public DbSet<FacturaDetalle> FacturaDetalles { get; set; }
        public DbSet<FacturaServicio> FacturaServicios { get; set; }
        public DbSet<SolicitudDTO> Solicitudes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            const string ADMIN_ID = "a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d";
            const string EMPLEADO_ID = "b2c3d4e5-f6a7-4b6c-9d0e-1f2a3b4c5d6e";

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ADMIN_ID,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "376dec87-a55e-476d-b561-3e5b35d5e7c9"
                },
                new IdentityRole
                {
                    Id = EMPLEADO_ID,
                    Name = "Empleado",
                    NormalizedName = "EMPLEADO",
                    ConcurrencyStamp = "8e426c7f-84b3-46f3-a43e-0ea60ca7e639"
                }
            );
        

            modelBuilder.Entity<TiposPropiedad>().HasData(
                new TiposPropiedad { TipoPropiedadId = 1, Descripcion = "Apartamento", Estado = Estados.Activo },
                new TiposPropiedad { TipoPropiedadId = 2, Descripcion = "Casa", Estado = Estados.Activo },
                new TiposPropiedad { TipoPropiedadId = 3, Descripcion = "Penthouse", Estado = Estados.Activo },
                new TiposPropiedad { TipoPropiedadId = 4, Descripcion = "Duplex", Estado = Estados.Activo },
                new TiposPropiedad { TipoPropiedadId = 5, Descripcion = "Villa", Estado = Estados.Activo },
                new TiposPropiedad { TipoPropiedadId = 6, Descripcion = "Local Comercial", Estado = Estados.Activo }
            );
        }


    }
}
