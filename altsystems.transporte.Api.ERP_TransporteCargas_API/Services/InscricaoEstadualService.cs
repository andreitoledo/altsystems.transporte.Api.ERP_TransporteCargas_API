namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Services
{
    using AutoMapper;
    using global::altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
    using global::altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
    using global::altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;
    using global::altsystems.transporte.Api.ERP_TransporteCargas_API.Services.Interfaces;

    namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Services
    {
        public class InscricaoEstadualService : IInscricaoEstadualService
        {
            private readonly IInscricaoEstadualRepository _repository;
            private readonly IMapper _mapper;

            public InscricaoEstadualService(IInscricaoEstadualRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<InscricaoEstadualDTO>> ObterPorClienteIdAsync(int clienteId)
            {
                var entidades = await _repository.GetByClienteIdAsync(clienteId);
                return _mapper.Map<IEnumerable<InscricaoEstadualDTO>>(entidades);
            }

            public async Task<InscricaoEstadualDTO> ObterPorIdAsync(int id)
            {
                var entidade = await _repository.GetByIdAsync(id);
                return _mapper.Map<InscricaoEstadualDTO>(entidade);
            }

            public async Task CriarAsync(int clienteId, InscricaoEstadualDTO dto)
            {
                var nova = _mapper.Map<InscricaoEstadual>(dto);
                nova.ClienteId = clienteId;
                await _repository.AddAsync(nova);
            }

            public async Task AtualizarAsync(int id, InscricaoEstadualDTO dto)
            {
                var existente = await _repository.GetByIdAsync(id);
                if (existente == null) return;

                existente.Numero = dto.Numero;
                existente.DataCadastro = dto.DataCadastro;
                await _repository.UpdateAsync(existente);
            }

            public async Task RemoverAsync(int id)
            {
                var existente = await _repository.GetByIdAsync(id);
                if (existente != null)
                {
                    await _repository.DeleteAsync(existente);
                }
            }
        }
    }

}
