using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Controllers
{
    [ApiController]
    [Route("api/Cliente/{clienteId}/InscricoesEstaduais")]
    public class InscricaoEstadualController : ControllerBase
    {
        private readonly IInscricaoEstadualService _service;

        public InscricaoEstadualController(IInscricaoEstadualService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InscricaoEstadualDTO>>> Get(int clienteId)
        {
            return Ok(await _service.ObterPorClienteIdAsync(clienteId));
        }

        [HttpPost]
        public async Task<IActionResult> Post(int clienteId, [FromBody] InscricaoEstadualDTO dto)
        {
            await _service.CriarAsync(clienteId, dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] InscricaoEstadualDTO dto)
        {
            await _service.AtualizarAsync(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.RemoverAsync(id);
            return Ok();
        }
    }

}
