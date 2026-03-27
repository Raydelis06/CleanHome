using CleanHome.DAL;
using CleanHome.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class OrdenCompraService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(OrdenCompra orden)
    {
        if (!await Existe(orden.OrdenCompraId))
        {
            return await Insertar(orden);
        }
        else
        {
            return await Modificar(orden);
        }
    }

    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.OrdenesCompra.AnyAsync(o => o.OrdenCompraId == id);
    }

    private async Task<bool> Insertar(OrdenCompra orden)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        orden.Total = orden.Detalles.Sum(d => d.Cantidad * d.Precio);

        contexto.OrdenesCompra.Add(orden);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(OrdenCompra orden)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        orden.Total = orden.Detalles.Sum(d => d.Cantidad * d.Precio);

        contexto.OrdenesCompra.Update(orden);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<List<OrdenCompra>> Listar(Expression<Func<OrdenCompra, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.OrdenesCompra
            .Include(o => o.Proveedor)
            .Include(o => o.Detalles)
            .ThenInclude(d => d.Material) 
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<OrdenCompra?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.OrdenesCompra
            .Include(o => o.Proveedor)
            .Include(o => o.Detalles)
            .ThenInclude(d => d.Material) // 🔥 CLAVE
            .FirstOrDefaultAsync(o => o.OrdenCompraId == id);
    }

    public async Task<bool> Confirmar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var orden = await contexto.OrdenesCompra
            .Include(o => o.Detalles)
            .FirstOrDefaultAsync(o => o.OrdenCompraId == id);

        if (orden == null)
            return false;

        foreach (var item in orden.Detalles)
        {
            var material = await contexto.Materiales
                .FirstOrDefaultAsync(m => m.MaterialId == item.MaterialId);

            if (material != null)
            {
                material.Cantidad += item.Cantidad;
                contexto.Materiales.Update(material);
            }
        }

        contexto.OrdenesCompra.Update(orden);

        return await contexto.SaveChangesAsync() > 0;
    }
}