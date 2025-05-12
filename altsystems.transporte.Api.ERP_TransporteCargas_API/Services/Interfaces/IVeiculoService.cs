using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;

namespace ERPTransporte.Services.Interfaces
{
    public interface IVeiculoService
    {
        Task<IEnumerable<VeiculoDTO>> ObterTodosAsync();
        Task<VeiculoDTO> ObterPorIdAsync(int id);
        Task<VeiculoDTO> CriarAsync(VeiculoDTO dto);
        Task AtualizarAsync(int id, VeiculoDTO dto);
        Task RemoverAsync(int id);
    }
}