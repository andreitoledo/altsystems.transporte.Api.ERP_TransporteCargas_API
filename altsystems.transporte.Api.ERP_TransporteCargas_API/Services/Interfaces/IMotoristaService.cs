using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Services.Interfaces
{
    public interface IMotoristaService
    {
        Task<List<MotoristaDTO>> ObterTodosAsync();
        Task<MotoristaDTO> ObterPorIdAsync(int id);
        Task CriarAsync(MotoristaDTO dto);
        Task AtualizarAsync(int id, MotoristaDTO dto);
        Task RemoverAsync(int id);
    }
}