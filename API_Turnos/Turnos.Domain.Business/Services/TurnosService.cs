using AutoMapper;
using Turnos.Aplication.DTO;
using Turnos.Domain.Business.Services.Contracts;
using Turnos.Domain.Model;
using Turnos.Infrastucture.Data.Repository.Contracts;

namespace Turnos.Domain.Business.Services
{
    public class TurnosService : ITurnosService
    {
        private readonly IGenericRepository<Turno> _genericRepository;
        private readonly IMapper _mapper;

        public TurnosService(IGenericRepository<Turno> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<List<TurnoDTO>> Listar(int id)
        {
            try
            {
                var listaTurnos = await _genericRepository.Consultar(t => t.IdServicio == id);
                return _mapper.Map<List<TurnoDTO>>(listaTurnos);
            }
            catch (Exception ex)
            {
                throw new Exception("Error no controlado", ex);
            }
        }
    }
}
