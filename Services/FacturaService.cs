using System.Linq.Expressions;
using CleanHome.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using CleanHome.Models;

namespace CleanHome.Services
{
    public class FacturaService(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> Guardar(Facturas factura)
        {
            if (!await Existe(factura.FacturaId))
            {
                return await Insertar(factura);
            }
            else
            {
                return await Modificar(factura);
            }
        }

        public async Task<bool> Existe(int facturaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Facturas.AnyAsync(f => f.FacturaId == facturaId);
        }

        private async Task<bool> Insertar(Facturas factura)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            await using var transaction = await contexto.Database.BeginTransactionAsync();

            try
            {
                var material = await contexto.Materiales
                    .FirstOrDefaultAsync(m => m.MaterialId == factura.MaterialId);

                if (material == null)
                    return false;

                
                if (material.CantidadDisponible < factura.Cantidad)
                    return false;

                
                material.CantidadDisponible -= factura.Cantidad;

                
                contexto.Facturas.Add(factura);

                await contexto.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }

        private async Task<bool> Modificar(Facturas factura)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Facturas.Update(factura);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(Facturas factura)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            factura.Estado = Estados.Inactivo;
            contexto.Facturas.Update(factura);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Recuperar(Facturas factura)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            factura.Estado = Estados.Activo;
            contexto.Facturas.Update(factura);
            return await contexto.SaveChangesAsync() > 0;
        }


        public async Task<List<Facturas>> Listar(Expression<Func<Facturas, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Facturas.Where(criterio).AsNoTracking().ToListAsync();
        }


        public async Task<List<Facturas>> Listar()
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Facturas.AsNoTracking().ToListAsync();
        }

        public async Task<Facturas?> Buscar(int facturaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Facturas.FirstOrDefaultAsync(f => f.FacturaId == facturaId);
        }
    }
}
