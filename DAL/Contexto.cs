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
    }
}
