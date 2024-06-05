using Turnos.Aplication.DTO;

namespace Turnos.Domain.Business.Services.Contracts
{
    public  interface IComercioService
    {
        Task<ComercioDTO> Crear(ComercioDTO modelo);
        Task<bool> Editar(ComercioDTO modelo);
        Task<bool> Eliminar(int id);
        Task<List<ComercioDTO>> Listar();
    }
}
