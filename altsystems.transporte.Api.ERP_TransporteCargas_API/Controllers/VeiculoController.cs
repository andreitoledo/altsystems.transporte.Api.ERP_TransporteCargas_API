using Microsoft.AspNetCore.Mvc;
using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Services;
using ERPTransporte.Services.Interfaces;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _service;

        public VeiculoController(IVeiculoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiculoDTO>>> Get() =>
            Ok(await _service.ObterTodosAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<VeiculoDTO>> Get(int id)
        {
            var veiculo = await _service.ObterPorIdAsync(id);
            if (veiculo == null) return NotFound();
            return Ok(veiculo);
        }

        [HttpPost]
        public async Task<ActionResult<VeiculoDTO>> Post(VeiculoDTO dto) =>
            Ok(await _service.CriarAsync(dto));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, VeiculoDTO dto)
        {
            await _service.AtualizarAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.RemoverAsync(id);
            return NoContent();
        }
    }
}