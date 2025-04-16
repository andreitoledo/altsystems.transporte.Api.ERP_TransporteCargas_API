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
    public class RelatoriosController : ControllerBase
    {
        private readonly ERPContext _context;

        public RelatoriosController(ERPContext context)
        {
            _context = context;
        }

        // GET: api/Relatorios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RelatorioFinanceiro>>> GetRelatoriosFinanceiros()
        {
            return await _context.RelatoriosFinanceiros.ToListAsync();
        }

        // GET: api/Relatorios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RelatorioFinanceiro>> GetRelatorioFinanceiro(int id)
        {
            var relatorio = await _context.RelatoriosFinanceiros.FindAsync(id);

            if (relatorio == null)
            {
                return NotFound();
            }

            return relatorio;
        }

        // POST: api/Relatorios
        [HttpPost]
        public async Task<ActionResult<RelatorioFinanceiro>> PostRelatorioFinanceiro(RelatorioFinanceiro relatorio)
        {
            _context.RelatoriosFinanceiros.Add(relatorio);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRelatorioFinanceiro), new { id = relatorio.Id }, relatorio);
        }
    }
}
