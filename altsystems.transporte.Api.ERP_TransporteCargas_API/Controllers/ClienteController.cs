using Microsoft.AspNetCore.Mvc;
using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Services;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientes()
        {
            var clientes = await _clienteService.ListarClientesAsync();
            var dtos = clientes.Select(c => new ClienteDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                Telefone = c.Telefone
            });
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> GetCliente(int id)
        {
            var cliente = await _clienteService.ObterClienteAsync(id);
            if (cliente == null) return NotFound();

            return Ok(new ClienteDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone
            });
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> PostCliente(ClienteCreateDTO dto)
        {
            var cliente = new Cliente
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Telefone = dto.Telefone
            };

            var criado = await _clienteService.CriarClienteAsync(cliente);
            return CreatedAtAction(nameof(GetCliente), new { id = criado.Id }, new ClienteDTO
            {
                Id = criado.Id,
                Nome = criado.Nome,
                Email = criado.Email,
                Telefone = criado.Telefone
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteUpdateDTO dto)
        {
            var cliente = await _clienteService.ObterClienteAsync(id);
            if (cliente == null) return NotFound();

            cliente.Nome = dto.Nome;
            cliente.Email = dto.Email;
            cliente.Telefone = dto.Telefone;

            await _clienteService.AtualizarClienteAsync(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _clienteService.ObterClienteAsync(id);
            if (cliente == null) return NotFound();

            await _clienteService.DeletarClienteAsync(id);
            return NoContent();
        }
    }
}
