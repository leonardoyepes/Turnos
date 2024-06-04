using System.Linq.Expressions;
using Turnos.Domain.Model;

namespace Turnos.Infrastucture.Data.Repository.Contracts
{
    public interface IComercioRepository
    {
        Task<Comercio> Obtener(Expression<Func<Comercio, bool>> filtro = null);
        Task<Comercio> Crear(Comercio entidad);
        Task<bool> Editar(Comercio entidad);
        Task<bool> Eliminar(Comercio entidad);
        Task<IQueryable<Comercio>> Consultar(Expression<Func<Comercio, bool>> filtro = null);
    }
}
