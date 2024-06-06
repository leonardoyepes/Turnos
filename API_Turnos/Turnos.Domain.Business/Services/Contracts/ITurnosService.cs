using Turnos.Aplication.DTO;
using Turnos.Domain.Model.Custom;

namespace Turnos.Domain.Business.Services.Contracts
{
    public interface ITurnosService
    {
        Task<List<TurnoDTO>> Listar(int id);
        Task<bool> GenerarTurnos(GenerarTurnosDTO modelo);
    }
}
