using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Services.Interfaces
{
    public interface IViagemService
    {
        Task<List<ViagemDTO>> ObterTodosAsync();
        Task<ViagemDTO?> ObterPorIdAsync(int id);
        Task CriarAsync(ViagemDTO dto);
        Task AtualizarAsync(ViagemDTO dto);
        Task RemoverAsync(int id);
    }
}
