using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces
{
    public interface IInscricaoEstadualRepository
    {
        Task<IEnumerable<InscricaoEstadual>> GetByClienteIdAsync(int clienteId);
        Task<InscricaoEstadual> GetByIdAsync(int id);
        Task AddAsync(InscricaoEstadual inscricaoEstadual);
        Task UpdateAsync(InscricaoEstadual inscricaoEstadual);
        Task DeleteAsync(InscricaoEstadual inscricaoEstadual);
    }
}
