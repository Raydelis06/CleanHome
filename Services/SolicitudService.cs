using CleanHome.DAL;
using CleanHome.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanHome.Services
{
    public class SolicitudService(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> Guardar(SolicitudDTO solicitud)
        {
            if (!await Existe(solicitud.Id))
            {
                return await Insertar(solicitud);
            }
            else
            {
                return await Modificar(solicitud);
            }
        }

        public async Task<bool> Existe(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Solicitudes.AnyAsync(a => a.Id == id);
        }

        private async Task<bool> Insertar(SolicitudDTO solicitud)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Solicitudes.Add(solicitud);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(SolicitudDTO solicitud)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Solicitudes.Update(solicitud);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(SolicitudDTO solicitud)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            solicitud.EstaInactiva = Estados.Inactivo;
            contexto.Solicitudes.Update(solicitud);
            return await contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Recuperar(SolicitudDTO solicitud)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            solicitud.EstaInactiva = Estados.Inactivo;
            contexto.Solicitudes.Update(solicitud);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<List<SolicitudDTO>> Listar(Expression<Func<SolicitudDTO, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Solicitudes.Where(criterio).AsNoTracking().ToListAsync();

        }
        public async Task<SolicitudDTO?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Solicitudes.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}