using CleanHome.DAL;
using CleanHome.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanHome.Services
{
    public class TiposPropiedadService(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<List<TiposPropiedad>> Listar(Expression<Func<TiposPropiedad, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.TiposPropiedad.Where(criterio).AsNoTracking().ToListAsync();

        }
    }
}
