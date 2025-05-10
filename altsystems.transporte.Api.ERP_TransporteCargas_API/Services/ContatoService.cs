using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<IEnumerable<ContatoDTO>> ListarAsync(int clienteId)
        {
            var contatos = await _contatoRepository.ObterPorClienteAsync(clienteId);
            return contatos.Select(c => new ContatoDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                Telefone = c.Telefone,
                ClienteId = c.ClienteId
            });
        }

        public async Task<ContatoDTO> AdicionarAsync(int clienteId, ContatoDTO dto)
        {
            var contato = new Contato
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Telefone = dto.Telefone,
                ClienteId = clienteId
            };

            var salvo = await _contatoRepository.AdicionarAsync(contato);

            return new ContatoDTO
            {
                Id = salvo.Id,
                Nome = salvo.Nome,
                Email = salvo.Email,
                Telefone = salvo.Telefone,
                ClienteId = salvo.ClienteId
            };
        }

        public async Task AtualizarAsync(int clienteId, int id, ContatoDTO dto)
        {
            var contato = new Contato
            {
                Id = id,
                Nome = dto.Nome,
                Email = dto.Email,
                Telefone = dto.Telefone,
                ClienteId = clienteId
            };

            await _contatoRepository.AtualizarAsync(id, contato);
        }

        public async Task RemoverAsync(int clienteId, int id)
        {
            await _contatoRepository.RemoverAsync(id);
        }
    }
}
