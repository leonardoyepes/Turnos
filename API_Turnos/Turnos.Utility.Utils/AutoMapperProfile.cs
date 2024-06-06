using AutoMapper;
using Turnos.Aplication.DTO;
using Turnos.Domain.Model;
using Turnos.Domain.Model.Custom;

namespace Turnos.Utility.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Comercio
            CreateMap<Comercio, ComercioDTO>().ReverseMap();
            #endregion Comercio

            #region Servicio
            CreateMap<Servicio, ServicioDTO>().ReverseMap();
            #endregion Servicio

            #region Turno
            CreateMap<Turno, TurnoDTO>().ReverseMap();
            CreateMap<GenerarTurnos, GenerarTurnosDTO>().ReverseMap();
            #endregion Turno
        }
    }
}
