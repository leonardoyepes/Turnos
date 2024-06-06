using System.Linq.Expressions;
using Turnos.Domain.Model;
using Turnos.Domain.Model.Custom;

namespace Turnos.Infrastucture.Data.Repository.Contracts
{
    public interface ITurnoRepository
    {
        Task<Turno> Obtener(Expression<Func<Turno, bool>> filtro = null);        
        Task<IQueryable<Turno>> Consultar(Expression<Func<Turno, bool>> filtro = null);
        Task<bool> GenerarTurnos(GenerarTurnos modelo);
    }
}
