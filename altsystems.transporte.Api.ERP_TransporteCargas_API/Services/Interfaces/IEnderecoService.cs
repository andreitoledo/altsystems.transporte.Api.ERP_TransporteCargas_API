using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;

public interface IEnderecoService
{
    Task<IEnumerable<EnderecoDTO>> ListarAsync(int clienteId);
    Task<EnderecoDTO> AdicionarAsync(int clienteId, EnderecoDTO dto);
    Task AtualizarAsync(int clienteId, int id, EnderecoDTO dto);
    Task RemoverAsync(int clienteId, int id);
}