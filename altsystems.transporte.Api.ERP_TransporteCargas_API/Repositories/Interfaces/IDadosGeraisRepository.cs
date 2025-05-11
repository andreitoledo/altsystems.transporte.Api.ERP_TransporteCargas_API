using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces
{
    public interface IDadosGeraisRepository
    {
        Task<List<DadosGerais>> ObterTodosPorClienteIdAsync(int clienteId);
        Task<DadosGerais> ObterPorClienteIdAsync(int clienteId);
        Task<DadosGerais> AdicionarOuAtualizarAsync(int clienteId, DadosGerais dados);
        Task<DadosGerais> ObterPorIdAsync(int id);
        Task AtualizarAsync(DadosGerais dados);
        Task RemoverAsync(DadosGerais dados);
        Task<DadosGerais> CriarAsync(DadosGerais dados);


    }
}
