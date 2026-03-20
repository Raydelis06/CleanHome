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
    }
}
