using System.Linq.Expressions;
using CleanHome.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using CleanHome.Models;

namespace CleanHome.Services;

public class ClienteService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(Clientes cliente)
    {
        if (!await Existe(cliente.ClienteId))
        {
            return await Insertar(cliente);
        }
        else
        {
            return await Modificar(cliente);
        }
    }

    public async Task<bool> Existe(int ClienteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Clientes.AnyAsync(a => a.ClienteId == ClienteId);

    }

    private async Task<bool> Insertar(Clientes cliente)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Clientes.Add(cliente);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Clientes cliente)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(cliente);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int clienteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Clientes.AsNoTracking().Where(a => a.ClienteId == clienteId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Clientes.Where(criterio).AsNoTracking().ToListAsync();

    }
    public async Task<Clientes?> Buscar(int clienteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Clientes.FirstOrDefaultAsync(e => e.ClienteId == clienteId);
    }



}

