using Microsoft.AspNetCore.Mvc;
using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Services;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargaController : ControllerBase
    {
        private readonly CargaService _service;

        public CargaController(CargaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CargaDTO>>> GetAll()
        {
            var items = await _service.ListarAsync();
            return Ok(items.Select(x => new CargaDTO
            {
                Id = x.Id,
                Tipo = x.Tipo ?? "Não informado",
                Peso = x.Peso,
                Descricao = x.Descricao,
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CargaDTO>> Get(int id)
        {
            var x = await _service.ObterAsync(id);
            if (x == null) return NotFound();

            return Ok(new CargaDTO
            {
                Id = x.Id,
                Tipo = x.Tipo ?? "Não informado",
                Peso = x.Peso,
                Descricao = x.Descricao,
            });
        }

        [HttpPost]
        public async Task<ActionResult<CargaDTO>> Post(Carga model)
        {
            var created = await _service.CriarAsync(model);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Carga model)
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