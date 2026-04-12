using System.Linq.Expressions;
using CleanHome.DAL;
using Microsoft.EntityFrameworkCore;
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

        
        public async Task<bool> Existe(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Facturas.AnyAsync(f => f.FacturaId == id);
        }

       
        private async Task<bool> Insertar(Facturas factura)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            foreach (var item in factura.Detalles)
            {
                var material = await contexto.Materiales
                    .FirstOrDefaultAsync(m => m.MaterialId == item.MaterialId);

                if (material != null)
                {
                    if (material.CantidadDisponible < item.Cantidad)
                    {
                        return false; 
                    }
                    material.CantidadDisponible -= item.Cantidad;
                }
            }

            factura.MontoTotal = factura.Detalles.Sum(d => d.Cantidad * d.Precio) + 
                                 factura.Servicios.Sum(s => s.Cantidad * s.Precio);
            factura.EstadoFactura = EstadosFactura.Pendiente;
            factura.Estado = Estados.Activo;

            contexto.Facturas.Add(factura);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Facturas facturaParam)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            var factura = await contexto.Facturas
                .Include(f => f.Detalles)
                .Include(f => f.Servicios)
                .FirstOrDefaultAsync(f => f.FacturaId == facturaParam.FacturaId);

            if (factura == null)
                return false;

            foreach (var detalleAnterior in factura.Detalles)
            {
                var material = await contexto.Materiales
                    .FirstOrDefaultAsync(m => m.MaterialId == detalleAnterior.MaterialId);

                if (material != null)
                {
                    material.CantidadDisponible += detalleAnterior.Cantidad;
                }
            }

            contexto.FacturaDetalles.RemoveRange(factura.Detalles);
            contexto.FacturaServicios.RemoveRange(factura.Servicios);

            foreach (var nuevoDetalle in facturaParam.Detalles)
            {
                var material = await contexto.Materiales
                    .FirstOrDefaultAsync(m => m.MaterialId == nuevoDetalle.MaterialId);

                if (material != null)
                {
                    if (material.CantidadDisponible < nuevoDetalle.Cantidad)
                    {
                        return false; 
                    }
                    material.CantidadDisponible -= nuevoDetalle.Cantidad;
                }

                factura.Detalles.Add(new FacturaDetalle
                {
                    FacturaId = factura.FacturaId,
                    MaterialId = nuevoDetalle.MaterialId,
                    Cantidad = nuevoDetalle.Cantidad,
                    Precio = nuevoDetalle.Precio
                });
            }

            foreach (var nuevoServicio in facturaParam.Servicios)
            {
                factura.Servicios.Add(new FacturaServicio
                {
                    FacturaId = factura.FacturaId,
                    ServicioId = nuevoServicio.ServicioId,
                    Cantidad = nuevoServicio.Cantidad,
                    Precio = nuevoServicio.Precio
                });
            }

            factura.Nombre = facturaParam.Nombre;
            factura.Fecha = facturaParam.Fecha;
            factura.MontoTotal = facturaParam.Detalles.Sum(d => d.Cantidad * d.Precio) + 
                                 facturaParam.Servicios.Sum(s => s.Cantidad * s.Precio);

            return await contexto.SaveChangesAsync() > 0;
        }

       
        public async Task<List<Facturas>> Listar(Expression<Func<Facturas, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            return await contexto.Facturas
                .Include(f => f.Cliente)
                .Include(f => f.Detalles)
                    .ThenInclude(d => d.Material)
                .Include(f => f.Servicios)
                    .ThenInclude(s => s.Servicio)
                .Where(criterio)
                .OrderByDescending(f => f.Fecha)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Facturas>> Listar()
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Facturas
                .Include(f => f.Cliente)
                .Include(f => f.Detalles)
                    .ThenInclude(d => d.Material)
                .Include(f => f.Servicios)
                    .ThenInclude(s => s.Servicio)
                .OrderByDescending(f => f.Fecha)
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task<Facturas?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            return await contexto.Facturas
                .Include(f => f.Cliente)
                .Include(f => f.Detalles)
                    .ThenInclude(d => d.Material)
                .Include(f => f.Servicios)
                    .ThenInclude(s => s.Servicio)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.FacturaId == id);
        }

        
        public async Task<bool> Confirmar(Facturas facturaParam)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            var factura = await contexto.Facturas
                .FirstOrDefaultAsync(f => f.FacturaId == facturaParam.FacturaId);

            if (factura == null || factura.EstadoFactura != EstadosFactura.Pendiente)
                return false;

            factura.EstadoFactura = EstadosFactura.Pagada;

            return await contexto.SaveChangesAsync() > 0;
        }

        
        public async Task<bool> Cancelar(Facturas facturaParam)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            var factura = await contexto.Facturas
                .Include(f => f.Detalles)
                .Include(f => f.Servicios)
                .FirstOrDefaultAsync(f => f.FacturaId == facturaParam.FacturaId);

            if (factura == null || factura.EstadoFactura != EstadosFactura.Pendiente)
                return false;

            foreach (var item in factura.Detalles)
            {
                var material = await contexto.Materiales
                    .FirstOrDefaultAsync(m => m.MaterialId == item.MaterialId);

                if (material != null)
                {
                    material.CantidadDisponible += item.Cantidad;
                }
            }

            factura.EstadoFactura = EstadosFactura.Cancelada;

            return await contexto.SaveChangesAsync() > 0;
        }

        
        public async Task<bool> Recuperar(Facturas facturaParam)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            var factura = await contexto.Facturas
                .Include(f => f.Detalles)
                .Include(f => f.Servicios)
                .FirstOrDefaultAsync(f => f.FacturaId == facturaParam.FacturaId);

            if (factura == null || factura.Estado != Estados.Inactivo)
                return false;

            foreach (var item in factura.Detalles)
            {
                var material = await contexto.Materiales
                    .FirstOrDefaultAsync(m => m.MaterialId == item.MaterialId);

                if (material != null)
                {
                    if (material.CantidadDisponible < item.Cantidad)
                    {
                        return false; 
                    }
                    material.CantidadDisponible -= item.Cantidad;
                }
            }

            factura.Estado = Estados.Activo;

            return await contexto.SaveChangesAsync() > 0;
        }


        public async Task<bool> Eliminar(Facturas facturaParam)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            var factura = await contexto.Facturas
                .Include(f => f.Detalles)
                .Include(f => f.Servicios)
                .FirstOrDefaultAsync(f => f.FacturaId == facturaParam.FacturaId);

            if (factura == null)
                return false;

         
            if (factura.Estado != Estados.Inactivo)
            {
                foreach (var item in factura.Detalles)
                {
                    var material = await contexto.Materiales
                        .FirstOrDefaultAsync(m => m.MaterialId == item.MaterialId);

                    if (material != null)
                    {
                        material.CantidadDisponible += item.Cantidad;
                    }
                }
            }

            
            factura.Estado = Estados.Inactivo;

            contexto.Facturas.Update(factura);

            return await contexto.SaveChangesAsync() > 0;
        }
    }
}
