using System.Linq.Expressions;
using Turnos.Domain.Model;

namespace Turnos.Infrastucture.Data.Repository.Contracts
{
    public interface ITurnoRepository
    {
        Task<Turno> Obtener(Expression<Func<Turno, bool>> filtro = null);        
        Task<IQueryable<Turno>> Consultar(Expression<Func<Turno, bool>> filtro = null);
    }
}
