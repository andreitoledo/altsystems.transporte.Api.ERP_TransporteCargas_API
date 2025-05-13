using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItinerarioController : ControllerBase
    {
        private readonly IItinerarioService _itinerarioService;

        public ItinerarioController(IItinerarioService itinerarioService)
        {
            _itinerarioService = itinerarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var itinerarios = await _itinerarioService.ObterTodosAsync();
            return Ok(itinerarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var itinerario = await _itinerarioService.ObterPorIdAsync(id);
            if (itinerario == null)
                return NotFound();

            return Ok(itinerario);
        }

        [HttpGet("viagem/{viagemId}")]
        public async Task<IActionResult> GetByViagemId(int viagemId)
        {
            var itinerarios = await _itinerarioService.ObterPorViagemIdAsync(viagemId);
            return Ok(itinerarios);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ItinerarioDTO dto)
        {
            await _itinerarioService.CriarAsync(dto);
            return CreatedAtAction(nameof(Get), null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ItinerarioDTO dto)
        {
            if (id != dto.Id)
                return BadRequest();

            await _itinerarioService.AtualizarAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _itinerarioService.ExcluirAsync(id);
            return NoContent();
        }
    }
}
