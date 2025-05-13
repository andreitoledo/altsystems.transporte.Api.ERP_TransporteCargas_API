using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoristaController : ControllerBase
    {
        private readonly IMotoristaService _service;

        public MotoristaController(IMotoristaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.ObterTodosAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _service.ObterPorIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MotoristaDTO dto)
        {
            await _service.CriarAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MotoristaDTO dto)
        {
            await _service.AtualizarAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.RemoverAsync(id);
            return Ok();
        }
    }
}