using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces
{
    public interface IItinerarioRepository
    {
        Task<List<Itinerario>> GetAllAsync();
        Task<Itinerario?> GetByIdAsync(int id);
        Task<List<Itinerario>> GetByViagemIdAsync(int viagemId);
        Task AddAsync(Itinerario itinerario);
        Task UpdateAsync(Itinerario itinerario);
        Task DeleteAsync(Itinerario itinerario);
        Task RemoverAsync(int id);

    }
}
