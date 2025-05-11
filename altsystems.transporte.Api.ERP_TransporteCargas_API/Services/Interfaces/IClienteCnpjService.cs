using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Services.Interfaces
{
    public interface IClienteCnpjService
    {
        Task<ClienteCnpjDTO> ObterPorClienteIdAsync(int clienteId);
        Task CriarOuAtualizarAsync(int clienteId, ClienteCnpjDTO dto);
        Task RemoverAsync(int clienteId);
        Task SalvarAsync(int clienteId, ClienteCnpjDTO dto);       

    }
}
