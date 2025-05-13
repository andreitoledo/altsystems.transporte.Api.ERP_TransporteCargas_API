using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Services.Interfaces
{
    public interface IItinerarioService
    {
        Task<List<ItinerarioDTO>> ObterTodosAsync();
        Task<ItinerarioDTO?> ObterPorIdAsync(int id);
        Task CriarAsync(ItinerarioDTO dto);
        Task AtualizarAsync(ItinerarioDTO dto);
        Task RemoverAsync(int id);
        Task<List<ItinerarioDTO>> ObterPorViagemIdAsync(int viagemId);
        Task ExcluirAsync(int id);


    }
}
