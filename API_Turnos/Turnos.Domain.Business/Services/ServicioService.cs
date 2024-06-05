using AutoMapper;
using Turnos.Aplication.DTO;
using Turnos.Domain.Business.Services.Contracts;
using Turnos.Domain.Model;
using Turnos.Infrastucture.Data.Repository.Contracts;

namespace Turnos.Domain.Business.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IGenericRepository<Servicio> _genericRepository;
        private readonly IMapper _mapper;

        public ServicioService(IGenericRepository<Servicio> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<ServicioDTO> Crear(ServicioDTO modelo)
        {
            try
            {
                var servicio = await _genericRepository.Crear(_mapper.Map<Servicio>(modelo));
                _ = servicio.IdServicio != 0 ? servicio : throw new TaskCanceledException("No fue posible crear el producto");

                return _mapper.Map<ServicioDTO>(servicio);
            }
            catch (Exception ex)
            {
                throw new Exception("Error no controlado", ex);
            }
        }

        public async Task<bool> Editar(ServicioDTO modelo)
        {
            try
            {
                var servicio = await _genericRepository.Obtener(m => m.IdServicio == modelo.IdServicio);
                _ = servicio ?? throw new Exception("No se encontro el comercio a editar");

                servicio.NomServicio = modelo.NomServicio;
                servicio.HoraApertura = modelo.HoraApertura;
                servicio.HoraCierre = modelo.HoraCierre;
                servicio.Duracion = modelo.Duracion;

                bool respuesta = await _genericRepository.Editar(servicio);
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
                var servicio = await _genericRepository.Obtener(m => m.IdServicio == id);
                _ = servicio ?? throw new Exception("No se encontro el comercio a eliminar");

                bool respuesta = await _genericRepository.Eliminar(servicio);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception("Error no controlado", ex);
            }
        }

        public async Task<List<ServicioDTO>> Listar()
        {
            try
            {
                var listaServicios = await _genericRepository.Consultar();
                return _mapper.Map<List<ServicioDTO>>(listaServicios);
            }
            catch (Exception ex)
            {
                throw new Exception("Error no controlado", ex);
            }
        }
    }
}
