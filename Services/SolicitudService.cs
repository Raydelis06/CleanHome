using CleanHome.Models;

namespace CleanHome.Services
{
    public class SolicitudService
    {
        private List<SolicitudDTO> _lista = new List<SolicitudDTO>();

        public List<SolicitudDTO> ObtenerSolicitudes()
        {
            return _lista;
        }
        public void Agregar(SolicitudDTO solicitud)
        {
            _lista.Add(solicitud);
        }

        public void Update(SolicitudDTO solicitud)
        {
            var existente = _lista.FirstOrDefault(s => s.Id == solicitud.Id);
            if (existente != null)
            {
                existente.Estado = solicitud.Estado;
            }
        }

        public void Delete(int id)
        {
            var solicitud = _lista.FirstOrDefault(s => s.Id == id);
            if (solicitud != null)
            {
                _lista.Remove(solicitud);
            }
        }
    }
}