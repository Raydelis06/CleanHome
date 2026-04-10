using CleanHome.DAL;
using CleanHome.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanHome.Services;

public class OrdenCompraService(IDbContextFactory<Contexto> DbFactory)
{
    // ========== GUARDAR ==========
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

    // ========== EXISTE ==========
    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.OrdenesCompra.AnyAsync(o => o.OrdenCompraId == id);
    }

    // ========== INSERTAR ==========
    private async Task<bool> Insertar(OrdenCompra orden)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        // Restar del stock al crear la orden
        foreach (var item in orden.Detalles)
        {
            var material = await contexto.Materiales
                .FirstOrDefaultAsync(m => m.MaterialId == item.MaterialId);

            if (material != null)
            {
                // Verificar que hay suficiente stock
                if (material.CantidadDisponible < item.Cantidad)
                {
                    return false; // No hay suficiente stock
                }
                material.CantidadDisponible -= item.Cantidad;
            }
        }

        orden.Total = orden.Detalles.Sum(d => d.Cantidad * d.Precio);
        orden.EstadoOrden = "Pendiente";
        orden.Estado = Estados.Activo;

        contexto.OrdenesCompra.Add(orden);
        return await contexto.SaveChangesAsync() > 0;
    }

    // ========== MODIFICAR ==========
    private async Task<bool> Modificar(OrdenCompra ordenParam)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var orden = await contexto.OrdenesCompra
            .Include(o => o.Detalles)
            .FirstOrDefaultAsync(o => o.OrdenCompraId == ordenParam.OrdenCompraId);

        if (orden == null)
            return false;

        // 1. Devolver el stock de los detalles anteriores
        foreach (var detalleAnterior in orden.Detalles)
        {
            var material = await contexto.Materiales
                .FirstOrDefaultAsync(m => m.MaterialId == detalleAnterior.MaterialId);

            if (material != null)
            {
                material.CantidadDisponible += detalleAnterior.Cantidad;
            }
        }

        // 2. Eliminar detalles anteriores
        contexto.OrdenesCompraDetalle.RemoveRange(orden.Detalles);

        // 3. Restar el stock de los nuevos detalles
        foreach (var nuevoDetalle in ordenParam.Detalles)
        {
            var material = await contexto.Materiales
                .FirstOrDefaultAsync(m => m.MaterialId == nuevoDetalle.MaterialId);

            if (material != null)
            {
                if (material.CantidadDisponible < nuevoDetalle.Cantidad)
                {
                    return false; // No hay suficiente stock
                }
                material.CantidadDisponible -= nuevoDetalle.Cantidad;
            }

            // Agregar nuevo detalle
            orden.Detalles.Add(new OrdenCompraDetalle
            {
                OrdenCompraId = orden.OrdenCompraId,
                MaterialId = nuevoDetalle.MaterialId,
                Cantidad = nuevoDetalle.Cantidad,
                Precio = nuevoDetalle.Precio
            });
        }

        // 4. Actualizar propiedades
        orden.ProveedorId = ordenParam.ProveedorId;
        orden.Fecha = ordenParam.Fecha;
        orden.Total = ordenParam.Detalles.Sum(d => d.Cantidad * d.Precio);

        return await contexto.SaveChangesAsync() > 0;
    }

    // ========== LISTAR ==========
    public async Task<List<OrdenCompra>> Listar(Expression<Func<OrdenCompra, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.OrdenesCompra
            .Include(o => o.Proveedor)
            .Include(o => o.Detalles)
                .ThenInclude(d => d.Material)
            .Where(criterio)
            .OrderByDescending(o => o.Fecha)
            .AsNoTracking()
            .ToListAsync();
    }

    // ========== BUSCAR ==========
    public async Task<OrdenCompra?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.OrdenesCompra
            .Include(o => o.Proveedor)
            .Include(o => o.Detalles)
                .ThenInclude(d => d.Material)
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.OrdenCompraId == id);
    }

    // ========== CONFIRMAR ==========
    public async Task<bool> Confirmar(OrdenCompra ordenParam)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var orden = await contexto.OrdenesCompra
            .FirstOrDefaultAsync(o => o.OrdenCompraId == ordenParam.OrdenCompraId);

        if (orden == null || orden.EstadoOrden != "Pendiente")
            return false;

        // Solo cambia el estado, el stock ya se restó al crear
        orden.EstadoOrden = "Confirmada";

        return await contexto.SaveChangesAsync() > 0;
    }

    // ========== CANCELAR ==========
    public async Task<bool> Cancelar(OrdenCompra ordenParam)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var orden = await contexto.OrdenesCompra
            .Include(o => o.Detalles)
            .FirstOrDefaultAsync(o => o.OrdenCompraId == ordenParam.OrdenCompraId);

        if (orden == null || orden.EstadoOrden != "Pendiente")
            return false;

        // Devolver el stock al cancelar
        foreach (var item in orden.Detalles)
        {
            var material = await contexto.Materiales
                .FirstOrDefaultAsync(m => m.MaterialId == item.MaterialId);

            if (material != null)
            {
                material.CantidadDisponible += item.Cantidad;
            }
        }

        orden.EstadoOrden = "Cancelada";
        orden.Estado = Estados.Inactivo;

        return await contexto.SaveChangesAsync() > 0;
    }

    // ========== RECUPERAR ==========
    public async Task<bool> Recuperar(OrdenCompra ordenParam)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var orden = await contexto.OrdenesCompra
            .Include(o => o.Detalles)
            .FirstOrDefaultAsync(o => o.OrdenCompraId == ordenParam.OrdenCompraId);

        if (orden == null || orden.EstadoOrden != "Cancelada")
            return false;

        // Volver a restar el stock al recuperar
        foreach (var item in orden.Detalles)
        {
            var material = await contexto.Materiales
                .FirstOrDefaultAsync(m => m.MaterialId == item.MaterialId);

            if (material != null)
            {
                if (material.CantidadDisponible < item.Cantidad)
                {
                    return false; // No hay suficiente stock para recuperar
                }
                material.CantidadDisponible -= item.Cantidad;
            }
        }

        orden.EstadoOrden = "Pendiente";
        orden.Estado = Estados.Activo;

        return await contexto.SaveChangesAsync() > 0;
    }

    // ========== ELIMINAR ==========
    // ========== ELIMINAR ==========
    public async Task<bool> Eliminar(OrdenCompra ordenParam)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        // Buscar la orden con sus detalles
        var orden = await contexto.OrdenesCompra
            .Include(o => o.Detalles)
            .FirstOrDefaultAsync(o => o.OrdenCompraId == ordenParam.OrdenCompraId);

        if (orden == null)
            return false;

        // Devolver stock si NO está cancelada
        if (orden.EstadoOrden != "Cancelada")
        {
            foreach (var item in orden.Detalles)
            {
                var material = await contexto.Materiales
                    .FirstOrDefaultAsync(m => m.MaterialId == item.MaterialId);

                if (material != null)
                {
                    material.CantidadDisponible += item.Cantidad;
                }
            }
        }

        // Eliminar detalles primero (usando los IDs)
        var detallesIds = orden.Detalles.Select(d => d.OrdenCompraDetalleId).ToList();
        var detallesAEliminar = await contexto.OrdenesCompraDetalle
            .Where(d => detallesIds.Contains(d.OrdenCompraDetalleId))
            .ToListAsync();

        contexto.OrdenesCompraDetalle.RemoveRange(detallesAEliminar);

        // Guardar eliminación de detalles primero
        await contexto.SaveChangesAsync();

        // Ahora eliminar la orden
        var ordenAEliminar = await contexto.OrdenesCompra
            .FirstOrDefaultAsync(o => o.OrdenCompraId == ordenParam.OrdenCompraId);

        if (ordenAEliminar != null)
        {
            contexto.OrdenesCompra.Remove(ordenAEliminar);
            return await contexto.SaveChangesAsync() > 0;
        }

        return false;
    }
}