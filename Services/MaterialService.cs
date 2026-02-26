using CleanHome.DAL;
using CleanHome.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanHome.Services
{
    public class MaterialService(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> Guardar(Materiales material)
        {
            if (!await Existe(material.MaterialId))
            {
                return await Insertar(material);
            }
            else
            {
                return await Modificar(material);
            }
        }

        public async Task<bool> Existe(int materialId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Materiales.AnyAsync(a => a.MaterialId == materialId);

        }

        private async Task<bool> Insertar(Materiales material)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Materiales.Add(material);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Materiales material)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(material);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(Materiales material)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            material.Estado = Estados.Inactivo;
            contexto.Update(material);
            return await contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Recuperar(Materiales material)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            material.Estado = Estados.Activo;
            contexto.Update(material);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<List<Materiales>> Listar(Expression<Func<Materiales, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Materiales.Where(criterio).AsNoTracking().ToListAsync();

        }
        public async Task<Materiales?> Buscar(int materialId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Materiales.FirstOrDefaultAsync(e => e.MaterialId == materialId);
        }
    }
}
