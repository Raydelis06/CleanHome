using CleanHome.DAL;
using CleanHome.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanHome.Services
{
    public class ProveedorService(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> Guardar(Proveedores proveedor)
        {
            if (!await Existe(proveedor.ProveedorId))
            {
                return await Insertar(proveedor);
            }
            else
            {
                return await Modificar(proveedor);
            }
        }

        public async Task<bool> Existe(int proveedorId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Proveedores.AnyAsync(a => a.ProveedorId == proveedorId );

        }

        private async Task<bool> Insertar(Proveedores proveedor)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Proveedores.Add(proveedor);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Proveedores proveedor)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(proveedor);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(Proveedores proveedor)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            proveedor.Estado = Estados.Inactivo;
            contexto.Update(proveedor);
            return await contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Recuperar(Proveedores proveedor)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            proveedor.Estado = Estados.Activo;
            contexto.Update(proveedor);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<List<Proveedores>> Listar(Expression<Func<Proveedores, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Proveedores.Where(criterio).AsNoTracking().ToListAsync();

        }
        public async Task<Proveedores?> Buscar(int clienteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Proveedores.FirstOrDefaultAsync(e => e.ProveedorId == clienteId);
        }
    }
}
