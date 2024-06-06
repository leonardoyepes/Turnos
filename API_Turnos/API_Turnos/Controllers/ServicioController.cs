using API_Turnos.Utilis;
using Microsoft.AspNetCore.Mvc;
using Turnos.Aplication.DTO;
using Turnos.Domain.Business.Services.Contracts;

namespace API_Turnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioService _servicioService;

        public ServicioController(IServicioService servicioService)
        {
            _servicioService = servicioService;
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] ServicioDTO modelo)
        {
            Response<ServicioDTO> _response = new();
            try
            {
                ServicioDTO servicioCreado = await _servicioService.Crear(modelo);

                if (servicioCreado.IdServicio != 0)
                    _response = new Response<ServicioDTO>() { State = true, Mesagge = "ok", Vaule = servicioCreado };
                else
                    _response = new Response<ServicioDTO>() { State = false, Mesagge = "No se pudo crear el servicio" };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<ServicioDTO>() { State = false, Mesagge = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            Response<List<ServicioDTO>> _response = new();

            try
            {
                List<ServicioDTO> listaServicios = new();
                listaServicios = await _servicioService.Listar();
                if (listaServicios.Count > 0)
                    _response = new Response<List<ServicioDTO>>() { State = true, Mesagge = "ok", Vaule = listaServicios };
                else
                    _response = new Response<List<ServicioDTO>>() { State = false, Mesagge = string.Empty, Vaule = null };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<List<ServicioDTO>>() { State = false, Mesagge = ex.Message, Vaule = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ServicioDTO modelo)
        {
            Response<bool> _response = new();
            try
            {
                bool respuesta = await _servicioService.Editar(modelo);
                if (respuesta)
                    _response = new Response<bool>() { State = true, Mesagge = "ok", Vaule = true };
                else
                    _response = new Response<bool>() { State = false, Mesagge = "No se pudo editar el servicio", Vaule = false };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<bool>() { State = false, Mesagge = ex.Message, Vaule = false };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            Response<bool> _response = new();
            try
            {
                bool respuesta = await _servicioService.Eliminar(id);

                if (respuesta)
                    _response = new Response<bool>() { State = true, Mesagge = "ok", Vaule = true };
                else
                    _response = new Response<bool>() { State = false, Mesagge = "No se pudo eliminar el servicio", Vaule = false };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<bool>() { State = false, Mesagge = ex.Message, Vaule = false };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
