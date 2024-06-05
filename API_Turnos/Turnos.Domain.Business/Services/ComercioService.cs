using AutoMapper;
using Turnos.Aplication.DTO;
using Turnos.Domain.Business.Services.Contracts;
using Turnos.Domain.Model;
using Turnos.Infrastucture.Data.Repository.Contracts;

namespace Turnos.Domain.Business.Services
{
    public class ComercioService : IComercioService
    {
        private readonly IGenericRepository<Comercio> _genericRepository;
        private readonly IMapper _mapper;

        public ComercioService(IGenericRepository<Comercio> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<ComercioDTO> Crear(ComercioDTO modelo)
        {
            try
            {
                var comercio = await _genericRepository.Crear(_mapper.Map<Comercio>(modelo));
                _ = comercio.IdComercio != 0 ? comercio : throw new TaskCanceledException("No fue posible crear el producto");

                return _mapper.Map<ComercioDTO>(comercio);
            }
            catch (Exception ex)
            {
                throw new Exception("Error no controlado", ex);
            }
        }

        public async Task<bool> Editar(ComercioDTO modelo)
        {
            try
            {
                var comercio = await _genericRepository.Obtener(m => m.IdComercio == modelo.IdComercio);
                _ = comercio ?? throw new Exception("No se encontro el comercio a editar");

                comercio.NomComercio = modelo.NomComercio;
                comercio.AforoMaximo = modelo.AforoMaximo;

                bool respuesta = await _genericRepository.Editar(comercio);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception("Error no controlado", ex);
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var comercio = await _genericRepository.Obtener(m => m.IdComercio == id);
                _ = comercio ?? throw new Exception("No se encontro el comercio a eliminar");

                bool respuesta = await _genericRepository.Eliminar(comercio);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception("Error no controlado", ex);
            }
        }

        public async Task<List<ComercioDTO>> Listar()
        {
            try
            {
                var listaComercios = await _genericRepository.Consultar();
                return _mapper.Map<List<ComercioDTO>>(listaComercios);
            }
            catch (Exception ex)
            {
                throw new Exception("Error no controlado", ex);
            }
        }
    }
}
