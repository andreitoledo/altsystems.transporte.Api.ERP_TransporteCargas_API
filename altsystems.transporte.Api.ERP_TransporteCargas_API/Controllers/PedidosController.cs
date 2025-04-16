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
    public class PedidosController : ControllerBase
    {
        private readonly ERPContext _context;

        public PedidosController(ERPContext context)
        {
            _context = context;
        }

        // GET: api/Pedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoTransporte>>> GetPedidosTransporte()
        {
            return await _context.PedidosTransporte.ToListAsync();
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoTransporte>> GetPedidoTransporte(int id)
        {
            var pedido = await _context.PedidosTransporte.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        // POST: api/Pedidos
        [HttpPost]
        public async Task<ActionResult<PedidoTransporte>> PostPedidoTransporte(PedidoTransporte pedido)
        {
            _context.PedidosTransporte.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPedidoTransporte), new { id = pedido.Id }, pedido);
        }
    }
}
