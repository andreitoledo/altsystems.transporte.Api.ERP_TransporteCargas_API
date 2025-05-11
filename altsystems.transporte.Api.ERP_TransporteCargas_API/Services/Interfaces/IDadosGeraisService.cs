using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Services.Interfaces
{
    public interface IDadosGeraisService
    {
        Task<List<DadosGerais>> ObterTodosPorClienteIdAsync(int clienteId);
        Task<DadosGeraisDTO> ObterAsync(int clienteId);
        Task<DadosGeraisDTO> SalvarAsync(int clienteId, DadosGeraisDTO dto);
        Task AtualizarAsync(int clienteId, int id, DadosGeraisDTO dto);
        Task RemoverAsync(int clienteId, int id);
        Task<DadosGerais> CriarAsync(DadosGerais dados);



    }
}
