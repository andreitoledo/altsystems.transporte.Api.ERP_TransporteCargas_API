using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Controllers
{
    [ApiController]
    [Route("api/Cliente/{clienteId}/DadosGerais")]
    public class DadosGeraisController : ControllerBase
    {
        private readonly IDadosGeraisService _service;

        public DadosGeraisController(IDadosGeraisService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<DadosGeraisDTO>> Get(int clienteId)
        {
            var dados = await _service.ObterAsync(clienteId);
            return Ok(dados);
        }

        [HttpPost]
        public async Task<ActionResult<DadosGeraisDTO>> Post(int clienteId, DadosGeraisDTO dto)
        {
            var result = await _service.SalvarAsync(clienteId, dto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int clienteId, int id, DadosGeraisDTO dto)
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
