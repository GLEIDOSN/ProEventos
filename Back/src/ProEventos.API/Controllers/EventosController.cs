using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Persistence;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Contexts;
using ProEventos.Application.Interfaces;
using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        public IEventoService eventoService;
        public EventosController(IEventoService eventoService)
        {
            this.eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await eventoService.GetAllEventosAsync(true);
                if (eventos == null) return NotFound("Nenhum evento encontrado.");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                       $"Erro ao tentar recuperar eventos. Erro: {ex.Message}.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var evento = await eventoService.GetEventoByIdAsync(id, true);
                if (evento == null) return NotFound("Nenhum evento encontrado.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                       $"Erro ao tentar recuperar evento por id. Erro: {ex.Message}.");
            }
        }

        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var evento = await eventoService.GetAllEventosByTemaAsync(tema, true);
                if (evento == null) return NotFound("Evento por tema não encontrado.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                       $"Erro ao tentar recuperar evento por tema. Erro: {ex.Message}.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            if (model == null) return BadRequest("Objeto enviado não pode ser nulo.");

            try
            {
                var evento = await eventoService.AddEvento(model);

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                       $"Erro ao tentar adicionar o evento. Erro: {ex.Message}.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            if (model == null) return BadRequest("Objeto enviado não pode ser nulo.");
            if (id <= 0) return BadRequest("Id não pode ser menor ou igual à zero.");

            try
            {
                var evento = await eventoService.UpdateEvento(id, model);

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                       $"Erro ao tentar atualizar o evento. Erro: {ex.Message}.");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletet(int id)
        {
            if (id <= 0) return BadRequest("Id não pode ser menor ou igual à zero.");

            try
            {
                return await eventoService.DeleteEvento(id) ?
                       Ok("Deletado") : 
                       BadRequest("Evento não deletado");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                       $"Erro ao tentar deletar o evento. Erro: {ex.Message}.");
            }
        }
    }
}
