using API_Turnos.Utilis;
using Microsoft.AspNetCore.Mvc;
using Turnos.Aplication.DTO;
using Turnos.Domain.Business.Services.Contracts;

namespace API_Turnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComercioController : ControllerBase
    {
        private readonly IComercioService _comercioService;

        public ComercioController(IComercioService comercioService)
        {
            _comercioService = comercioService;
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] ComercioDTO modelo)
        {
            Response<ComercioDTO> _response = new();
            try
            {
                ComercioDTO comercioCreado = await _comercioService.Crear(modelo);

                if (comercioCreado.IdComercio != 0)
                    _response = new Response<ComercioDTO>() { State = true, Mesagge = "ok", Vaule = comercioCreado };
                else
                    _response = new Response<ComercioDTO>() { State = false, Mesagge = "No se pudo crear el comercio" };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<ComercioDTO>() { State = false, Mesagge = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            Response<List<ComercioDTO>> _response = new();

            try
            {
                List<ComercioDTO> listaComercios = new();
                listaComercios = await _comercioService.Listar();
                if (listaComercios.Count > 0)
                    _response = new Response<List<ComercioDTO>>() { State = true, Mesagge = "ok", Vaule = listaComercios };
                else
                    _response = new Response<List<ComercioDTO>>() { State = false, Mesagge = string.Empty, Vaule = null };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<List<ComercioDTO>>() { State = false, Mesagge = ex.Message, Vaule = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }            
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ComercioDTO modelo)
        {
            Response<bool> _response = new();
            try
            {
                bool respuesta = await _comercioService.Editar(modelo);
                if (respuesta)
                    _response = new Response<bool>() { State = true, Mesagge = "ok", Vaule = true };
                else
                    _response = new Response<bool>() { State = false, Mesagge = "No se pudo editar el comercio", Vaule = false };

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
                bool respuesta = await _comercioService.Eliminar(id);

                if (respuesta)
                    _response = new Response<bool>() { State = true, Mesagge = "ok", Vaule = true };
                else
                    _response = new Response<bool>() { State = false, Mesagge = "No se pudo eliminar el comercio", Vaule = false };

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
