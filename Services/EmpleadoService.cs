using System.Linq.Expressions;
using CleanHome.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using CleanHome.Models;


namespace CleanHome.Services
{
    public class EmpleadoService(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> Guardar(Empleados empleado)
        {
            if (!await Existe(empleado.EmpleadoId))
            {
                return await Insertar(empleado);
            }
            else
            {
                return await Modificar(empleado);
            }
        }

        public async Task<bool> Existe(int empleadoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Empleados.AnyAsync(a => a.EmpleadoId == empleadoId);
        }

        private async Task<bool> Insertar(Empleados empleado)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Empleados.Add(empleado);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Empleados empleado)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(empleado);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(int empleadoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Empleados.AsNoTracking().Where(a => a.EmpleadoId == empleadoId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Empleados>> Listar(Expression<Func<Empleados, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Empleados.Where(criterio).AsNoTracking().ToListAsync();

        }
        public async Task<Empleados?> Buscar(int empleadoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Empleados.FirstOrDefaultAsync(e => e.EmpleadoId == empleadoId);
        }



    }
}
