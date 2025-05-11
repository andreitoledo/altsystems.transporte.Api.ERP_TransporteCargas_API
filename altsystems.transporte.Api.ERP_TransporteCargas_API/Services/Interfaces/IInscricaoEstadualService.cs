using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Services.Interfaces
{
    public interface IInscricaoEstadualService
    {
        Task<IEnumerable<InscricaoEstadualDTO>> ObterPorClienteIdAsync(int clienteId);
        Task<InscricaoEstadualDTO> ObterPorIdAsync(int id);
        Task CriarAsync(int clienteId, InscricaoEstadualDTO dto);
        Task AtualizarAsync(int id, InscricaoEstadualDTO dto);
        Task RemoverAsync(int id);
    }
}
