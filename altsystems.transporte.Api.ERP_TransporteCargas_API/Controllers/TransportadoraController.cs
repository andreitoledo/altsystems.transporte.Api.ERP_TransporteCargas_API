using Microsoft.AspNetCore.Mvc;
using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Services;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportadoraController : ControllerBase
    {
        private readonly TransportadoraService _service;

        public TransportadoraController(TransportadoraService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransportadoraDTO>>> GetAll()
        {
            var items = await _service.ListarAsync();
            return Ok(items.Select(x => new TransportadoraDTO
            {
                Id = x.Id,
                Nome = x.Nome,
                CNPJ = x.CNPJ,
                Contato = x.Contato,
                Telefone = x.Telefone,
                Email = x.Email,
                
                
                
                
                
                
                
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransportadoraDTO>> Get(int id)
        {
            var x = await _service.ObterAsync(id);
            if (x == null) return NotFound();

            return Ok(new TransportadoraDTO
            {
                Id = x.Id,
                Nome = x.Nome,
                CNPJ = x.CNPJ,
                Contato = x.Contato,
                Telefone = x.Telefone,
                Email = x.Email,
                
                
                
                
                
                
                
            });
        }

        [HttpPost]
        public async Task<ActionResult<TransportadoraDTO>> Post(Transportadora model)
        {
            var created = await _service.CriarAsync(model);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Transportadora model)
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