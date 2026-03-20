using CleanHome.DAL;
using CleanHome.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanHome.Services
{
    public class PropiedadService(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> Guardar(Propiedades propiedad)
        {
            if (!await Existe(propiedad.PropiedadId))
            {
                return await Insertar(propiedad);
            }
            else
            {
                return await Modificar(propiedad);
            }
        }
        public async Task<bool> Existe(int propiedadId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Propiedades.AnyAsync(a => a.PropiedadId == propiedadId);

        }
        private async Task<bool> Insertar(Propiedades propiedad)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Propiedades.Add(propiedad);
            return await contexto.SaveChangesAsync() > 0;
        }
        private async Task<bool> Modificar(Propiedades propiedad)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Propiedades.Update(propiedad);
            return await contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Eliminar(Propiedades propiedad)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            propiedad.Estado = Estados.Inactivo;
            contexto.Propiedades.Update(propiedad);
            return await contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Recuperar(Propiedades propiedad)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            propiedad.Estado = Estados.Activo;
            contexto.Propiedades.Update(propiedad);
            return await contexto.SaveChangesAsync() > 0;
        }
        public async Task<List<Propiedades>> Listar(Expression<Func<Propiedades, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Propiedades.Where(criterio).AsNoTracking().ToListAsync();

        }
        public async Task<Propiedades?> Buscar(int propiedadId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Propiedades.FirstOrDefaultAsync(e => e.PropiedadId == propiedadId);
        }
    }
}
