using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Services.Interfaces
{
    public interface IDadosGeraisService
    {
        Task<DadosGeraisDTO> ObterAsync(int clienteId);
        Task<DadosGeraisDTO> SalvarAsync(int clienteId, DadosGeraisDTO dto);
        Task AtualizarAsync(int clienteId, int id, DadosGeraisDTO dto);
        Task RemoverAsync(int clienteId, int id);

    }
}
