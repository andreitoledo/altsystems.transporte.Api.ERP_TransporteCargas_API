using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Services.Interfaces;
using AutoMapper;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Services
{
    public class ClienteCnpjService : IClienteCnpjService
    {
        private readonly IClienteCnpjRepository _repository;
        private readonly IMapper _mapper;

        public ClienteCnpjService(IClienteCnpjRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClienteCnpjDTO> ObterPorClienteIdAsync(int clienteId)
        {
            var entity = await _repository.GetByClienteIdAsync(clienteId);
            return _mapper.Map<ClienteCnpjDTO>(entity);
        }

        public async Task CriarOuAtualizarAsync(int clienteId, ClienteCnpjDTO dto)
        {
            var existente = await _repository.GetByClienteIdAsync(clienteId);
            if (existente == null)
            {
                var novo = _mapper.Map<ClienteCnpj>(dto);
                novo.ClienteId = clienteId;
                await _repository.AddAsync(novo);
            }
            else
            {
                existente.Cnpj = dto.Cnpj;
                existente.DataCadastro = dto.DataCadastro;
                await _repository.UpdateAsync(existente);
            }
        }

        public async Task RemoverAsync(int clienteId)
        {
            var existente = await _repository.GetByClienteIdAsync(clienteId);
            if (existente != null)
            {
                await _repository.DeleteAsync(existente);
            }
        }

        public async Task SalvarAsync(int clienteId, ClienteCnpjDTO dto)
        {
            var entity = _mapper.Map<ClienteCnpj>(dto);
            entity.ClienteId = clienteId;

            await _repository.AddAsync(entity);

        }

    }
}
