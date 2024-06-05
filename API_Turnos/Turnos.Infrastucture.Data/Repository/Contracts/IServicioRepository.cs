using System.Linq.Expressions;
using Turnos.Domain.Model;

namespace Turnos.Infrastucture.Data.Repository.Contracts
{
    public interface IServicioRepository
    {
        Task<Servicio> Obtener(Expression<Func<Servicio, bool>> filtro = null);
        Task<Servicio> Crear(Servicio entidad);
        Task<bool> Editar(Servicio entidad);
        Task<bool> Eliminar(Servicio entidad);
        Task<IQueryable<Servicio>> Consultar(Expression<Func<Servicio, bool>> filtro = null);
    }
}
