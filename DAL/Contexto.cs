using CleanHome.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanHome.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Materiales> Materiales { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<Propiedades> Propiedades { get; set; }
        public DbSet<TiposPropiedad> TiposPropiedad { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
