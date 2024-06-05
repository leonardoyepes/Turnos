using Turnos.Aplication.DTO;

namespace Turnos.Domain.Business.Services.Contracts
{
    public interface IServicioService
    {
        Task<ServicioDTO> Crear(ServicioDTO modelo);
        Task<bool> Editar(ServicioDTO modelo);
        Task<bool> Eliminar(int id);
        Task<List<ServicioDTO>> Listar();
    }
}
