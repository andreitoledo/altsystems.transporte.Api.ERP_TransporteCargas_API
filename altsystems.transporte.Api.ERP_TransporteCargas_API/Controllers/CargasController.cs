using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Data;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargasController : ControllerBase
    {
        private readonly ERPContext _context;

        public CargasController(ERPContext context)
        {
            _context = context;
        }

        // GET: api/Cargas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carga>>> GetCargas()
        {
            return await _context.Cargas.ToListAsync();
        }

        // GET: api/Cargas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carga>> GetCarga(int id)
        {
            var carga = await _context.Cargas.FindAsync(id);

            if (carga == null)
            {
                return NotFound();
            }

            return carga;
        }

        // POST: api/Cargas
        [HttpPost]
        public async Task<ActionResult<Carga>> PostCarga(Carga carga)
        {
            _context.Cargas.Add(carga);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarga), new { id = carga.Id }, carga);
        }
    }
}
