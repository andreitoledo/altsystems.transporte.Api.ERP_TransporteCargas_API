using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Data;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportadorasController : ControllerBase
    {
        private readonly ERPContext _context;

        public TransportadorasController(ERPContext context)
        {
            _context = context;
        }

        // GET: api/Transportadoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transportadora>>> GetTransportadoras()
        {
            return await _context.Transportadoras.ToListAsync();
        }

        // GET: api/Transportadoras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transportadora>> GetTransportadora(int id)
        {
            var transportadora = await _context.Transportadoras.FindAsync(id);

            if (transportadora == null)
            {
                return NotFound();
            }

            return transportadora;
        }

        // POST: api/Transportadoras
        [HttpPost]
        public async Task<ActionResult<Transportadora>> PostTransportadora(Transportadora transportadora)
        {
            _context.Transportadoras.Add(transportadora);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTransportadora), new { id = transportadora.Id }, transportadora);
        }

        // PUT: api/Transportadoras/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransportadora(int id, Transportadora transportadora)
        {
            if (id != transportadora.Id)
            {
                return BadRequest(new { mensagem = "O ID da URL não bate com o corpo da requisição." });
            }

            _context.Entry(transportadora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportadoraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Transportadoras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Transportadora>> DeleteTransportadora(int id)
        {
            var transportadora = await _context.Transportadoras.FindAsync(id);
            if (transportadora == null)
            {
                return NotFound();
            }

            _context.Transportadoras.Remove(transportadora);
            await _context.SaveChangesAsync();

            return transportadora;
        }

        private bool TransportadoraExists(int id)
        {
            return _context.Transportadoras.Any(e => e.Id == id);
        }
    }
}
