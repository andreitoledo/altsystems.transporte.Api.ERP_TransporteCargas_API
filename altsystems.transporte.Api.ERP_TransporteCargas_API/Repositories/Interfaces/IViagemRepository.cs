using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces
{
    public interface IViagemRepository
    {
        Task<IEnumerable<Viagem>> GetAllAsync();
        Task<Viagem> GetByIdAsync(int id);
        Task AddAsync(Viagem viagem);
        Task UpdateAsync(Viagem viagem);
        Task DeleteAsync(Viagem viagem);
    }
}
