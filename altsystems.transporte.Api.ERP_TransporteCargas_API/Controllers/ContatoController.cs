using Microsoft.AspNetCore.Mvc;
using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Controllers
{
    [Route("api/Cliente/{clienteId}/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _service;

        public ContatoController(IContatoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int clienteId)
        {
            var result = await _service.ListarAsync(clienteId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(int clienteId, ContatoDTO dto)
        {
            var result = await _service.AdicionarAsync(clienteId, dto);
            return CreatedAtAction(nameof(Get), new { clienteId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int clienteId, int id, ContatoDTO dto)
        {
            await _service.AtualizarAsync(clienteId, id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int clienteId, int id)
        {
            await _service.RemoverAsync(clienteId, id);
            return NoContent();
        }
    }
}