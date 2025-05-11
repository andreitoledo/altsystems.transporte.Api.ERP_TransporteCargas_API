using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Controllers
{
    [ApiController]
    [Route("api/Cliente/{clienteId}/DadosGerais")]
    public class DadosGeraisController : ControllerBase
    {
        private readonly IDadosGeraisService _service;
        private readonly IMapper _mapper;

        public DadosGeraisController(IDadosGeraisService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<DadosGeraisDTO>> Get(int clienteId)
        {
            var dados = await _service.ObterTodosPorClienteIdAsync(clienteId);
            return Ok(_mapper.Map<IEnumerable<DadosGeraisDTO>>(dados));
        }

        [HttpPost]
        public async Task<ActionResult<DadosGeraisDTO>> Post(int clienteId, DadosGeraisDTO dto)
        {
            var entity = _mapper.Map<DadosGerais>(dto);
            entity.ClienteId = clienteId;

            var result = await _service.CriarAsync(entity);
            return Ok(_mapper.Map<DadosGeraisDTO>(result));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int clienteId, int id, DadosGeraisDTO dto)
        {
            await _service.AtualizarAsync(clienteId, id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int clienteId, int id)
        {
            await _service.RemoverAsync(clienteId, id);
            return NoContent();
        }

    }

}
