using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;

public interface IContatoService
{
    Task<IEnumerable<ContatoDTO>> ListarAsync(int clienteId);
    Task<ContatoDTO> AdicionarAsync(int clienteId, ContatoDTO dto);
    Task AtualizarAsync(int clienteId, int id, ContatoDTO dto);
    Task RemoverAsync(int clienteId, int id);
}