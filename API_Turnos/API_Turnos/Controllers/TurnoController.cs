﻿using API_Turnos.Utilis;
using Microsoft.AspNetCore.Mvc;
using Turnos.Aplication.DTO;
using Turnos.Domain.Business.Services.Contracts;

namespace API_Turnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly ITurnosService _turnosService;

        public TurnoController(ITurnosService turnosService)
        {
            _turnosService = turnosService;
        }

        [HttpPost]
        [Route("GenerarTurnos")]
        public async Task<IActionResult> Guardar([FromBody] GenerarTurnosDTO modelo)
        {
            Response<bool> _response = new();
            try
            {   
                bool turnosGenerados = await _turnosService.GenerarTurnos(modelo);

                if (turnosGenerados)
                    _response = new Response<bool>() { State = true, Mesagge = "ok", Vaule = true };
                else
                    _response = new Response<bool>() { State = false, Mesagge = "No se pudo crear el servicio" };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<bool>() { State = false, Mesagge = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista(int idServicio)
        {
            Response<List<TurnoDTO>> _response = new();

            try
            {
                List<TurnoDTO> listaTurnos = new();
                listaTurnos = await _turnosService.Listar(idServicio);
                if (listaTurnos.Count > 0)
                    _response = new Response<List<TurnoDTO>>() { State = true, Mesagge = "ok", Vaule = listaTurnos };
                else
                    _response = new Response<List<TurnoDTO>>() { State = false, Mesagge = string.Empty, Vaule = null };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<List<TurnoDTO>>() { State = false, Mesagge = ex.Message, Vaule = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
