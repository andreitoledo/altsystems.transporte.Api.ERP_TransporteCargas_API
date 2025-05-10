using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<IEnumerable<EnderecoDTO>> ListarAsync(int clienteId)
        {
            var lista = await _enderecoRepository.ObterPorClienteAsync(clienteId);
            return lista.Select(e => new EnderecoDTO
            {
                Id = e.Id,
                Logradouro = e.Logradouro,
                Cidade = e.Cidade,
                Estado = e.Estado,
                ClienteId = e.ClienteId
            });
        }

        public async Task<EnderecoDTO> AdicionarAsync(int clienteId, EnderecoDTO dto)
        {
            var endereco = new Endereco
            {
                Logradouro = dto.Logradouro,
                Cidade = dto.Cidade,
                Estado = dto.Estado,
                ClienteId = clienteId
            };

            var salvo = await _enderecoRepository.AdicionarAsync(endereco);

            return new EnderecoDTO
            {
                Id = salvo.Id,
                Logradouro = salvo.Logradouro,
                Cidade = salvo.Cidade,
                Estado = salvo.Estado,
                ClienteId = salvo.ClienteId
            };
        }

        public async Task AtualizarAsync(int clienteId, int id, EnderecoDTO dto)
        {
            var endereco = new Endereco
            {
                Id = id,
                Logradouro = dto.Logradouro,
                Cidade = dto.Cidade,
                Estado = dto.Estado,
                ClienteId = clienteId
            };

            await _enderecoRepository.AtualizarAsync(id, endereco);
        }

        public async Task RemoverAsync(int clienteId, int id)
        {
            await _enderecoRepository.RemoverAsync(id);
        }
    }
}
