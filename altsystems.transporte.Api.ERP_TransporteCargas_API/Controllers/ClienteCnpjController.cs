using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Controllers
{
    [ApiController]
    [Route("api/Cliente/{clienteId}/Cnpj")]
    public class ClienteCnpjController : ControllerBase
    {
        private readonly IClienteCnpjService _service;

        public ClienteCnpjController(IClienteCnpjService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ClienteCnpjDTO>> Get(int clienteId)
        {
            return Ok(await _service.ObterPorClienteIdAsync(clienteId));
        }

        [HttpPost]
        public async Task<IActionResult> Post(int clienteId, [FromBody] ClienteCnpjDTO dto)
        {
            await _service.SalvarAsync(clienteId, dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int clienteId, int id, ClienteCnpjDTO dto)
        {
            var existente = await _service.GetByIdAsync(id); // ou um método que verifica por ID
            if (existente == null || existente.ClienteId != clienteId)
                return NotFound();

            existente.Cnpj = dto.Cnpj;
            existente.DataCadastro = dto.DataCadastro;

            await _service.UpdateAsync(existente);
            return NoContent();
        }       

        [HttpDelete] // também herda o clienteId da rota do controller
        public async Task<IActionResult> Delete(int clienteId)
        {
            await _service.RemoverAsync(clienteId);
            return Ok();
        }

    }
}
