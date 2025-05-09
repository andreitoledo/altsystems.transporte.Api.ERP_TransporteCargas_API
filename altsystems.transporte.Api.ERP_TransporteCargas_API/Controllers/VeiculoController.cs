using Microsoft.AspNetCore.Mvc;
using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Services;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly VeiculoService _service;

        public VeiculoController(VeiculoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiculoDTO>>> GetAll()
        {
            var items = await _service.ListarAsync();
            return Ok(items.Select(x => new VeiculoDTO
            {
                Id = x.Id,
                Placa = x.Placa,
                Modelo = x.Modelo,
                Tipo = x.Tipo,
                Ano = x.Ano,   
                
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VeiculoDTO>> Get(int id)
        {
            var x = await _service.ObterAsync(id);
            if (x == null) return NotFound();

            return Ok(new VeiculoDTO
            {
                Id = x.Id,
                Placa = x.Placa,
                Modelo = x.Modelo,
                Tipo = x.Tipo,
                Ano = x.Ano,  
                
            });
        }

        [HttpPost]
        public async Task<ActionResult<VeiculoDTO>> Post(Veiculo model)
        {
            var created = await _service.CriarAsync(model);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Veiculo model)
        {
            if (id != model.Id) return BadRequest();
            await _service.AtualizarAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _service.ObterAsync(id);
            if (existing == null) return NotFound();
            await _service.DeletarAsync(id);
            return NoContent();
        }
    }
}