using altsystems.transporte.Api.ERP_TransporteCargas_API.Data;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class VeiculosController : ControllerBase
{
    private readonly ERPContext _context;

    public VeiculosController(ERPContext context)
    {
        _context = context;
    }

    // GET: api/veiculos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
    {
        return await _context.Veiculos.ToListAsync();
    }

    // POST: api/veiculos
    [HttpPost]
    public async Task<ActionResult<Veiculo>> PostVeiculo(Veiculo veiculo)
    {
        _context.Veiculos.Add(veiculo);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetVeiculos", new { id = veiculo.Id }, veiculo);
    }
}
