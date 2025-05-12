using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces
{
    public interface IClienteCnpjRepository
    {
        Task<ClienteCnpj> GetByClienteIdAsync(int clienteId);
        Task AddAsync(ClienteCnpj clienteCnpj);
        Task UpdateAsync(ClienteCnpj clienteCnpj);
        Task DeleteAsync(ClienteCnpj clienteCnpj);
        Task<ClienteCnpj> GetByIdAsync(int id);

    }
}
