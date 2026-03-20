using System.Linq.Expressions;
using CleanHome.DAL;
using Microsoft.EntityFrameworkCore;
using CleanHome.Models;

namespace CleanHome.Services;

public class ServicioService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(Servicios servicio)
    {
        if (!await Existe(servicio.ServicioId))
        {
            return await Insertar(servicio);
        }
        else
        {
            return await Modificar(servicio);
        }
    }

    public async Task<bool> Existe(int servicioId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Servicios.AnyAsync(s => s.ServicioId == servicioId);
    }

    private async Task<bool> Insertar(Servicios servicio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        
        var material = await contexto.Materiales
            .FirstOrDefaultAsync(m => m.MaterialId == servicio.MaterialId);

        
        if (material == null || material.CantidadDisponible <= 0)
            return false;

        
        material.CantidadDisponible -= 1;

        contexto.Servicios.Add(servicio);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Servicios servicio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Servicios.Update(servicio);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(Servicios servicio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        servicio.Estado = Estados.Inactivo;
        contexto.Servicios.Update(servicio);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Recuperar(Servicios servicio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        servicio.Estado = Estados.Activo;
        contexto.Servicios.Update(servicio);
        return await contexto.SaveChangesAsync() > 0;
    }

    
    public async Task<List<Servicios>> Listar(Expression<Func<Servicios, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Servicios.Where(criterio).AsNoTracking().ToListAsync();
    }

    
    public async Task<List<Servicios>> Listar()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Servicios.AsNoTracking().ToListAsync();
    }

    public async Task<Servicios?> Buscar(int servicioId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Servicios.FirstOrDefaultAsync(s => s.ServicioId == servicioId);
    }
}