using Turnos.Aplication.DTO;

namespace Turnos.Domain.Business.Services.Contracts
{
    public interface ITurnosService
    {
        Task<List<TurnoDTO>> Listar(int id);
    }
}
