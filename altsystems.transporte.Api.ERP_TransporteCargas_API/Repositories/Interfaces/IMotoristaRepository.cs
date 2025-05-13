using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces
{
    public interface IMotoristaRepository
    {
        Task<List<Motorista>> GetAllAsync();
        Task<Motorista> GetByIdAsync(int id);
        Task AddAsync(Motorista entity);
        Task UpdateAsync(Motorista entity);
        Task DeleteAsync(Motorista entity);
    }
}