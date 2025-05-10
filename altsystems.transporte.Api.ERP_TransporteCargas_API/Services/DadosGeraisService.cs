using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Services.Interfaces;
using AutoMapper;

public class DadosGeraisService : IDadosGeraisService
{
    private readonly IDadosGeraisRepository _repo;
    private readonly IMapper _mapper;

    public DadosGeraisService(IDadosGeraisRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<DadosGeraisDTO> ObterAsync(int clienteId)
    {
        var dados = await _repo.ObterPorClienteIdAsync(clienteId);
        return _mapper.Map<DadosGeraisDTO>(dados);
    }

    public async Task<DadosGeraisDTO> SalvarAsync(int clienteId, DadosGeraisDTO dto)
    {
        var entidade = _mapper.Map<DadosGerais>(dto);
        var resultado = await _repo.AdicionarOuAtualizarAsync(clienteId, entidade);
        return _mapper.Map<DadosGeraisDTO>(resultado);
    }

    public async Task AtualizarAsync(int clienteId, int id, DadosGeraisDTO dto)
    {
        var entity = await _repo.ObterPorIdAsync(id);
        if (entity == null || entity.ClienteId != clienteId)
            throw new KeyNotFoundException("Registro não encontrado.");

        _mapper.Map(dto, entity); // atualiza os campos da entidade
        await _repo.AtualizarAsync(entity);
    }

    public async Task RemoverAsync(int clienteId, int id)
    {
        var entity = await _repo.ObterPorIdAsync(id);
        if (entity == null || entity.ClienteId != clienteId)
            throw new KeyNotFoundException("Registro não encontrado.");

        await _repo.RemoverAsync(entity);
    }

}
