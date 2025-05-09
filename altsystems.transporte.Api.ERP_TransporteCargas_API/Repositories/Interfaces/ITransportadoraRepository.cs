using System.Collections.Generic;
using System.Threading.Tasks;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces
{
    public interface ITransportadoraRepository
    {
        Task<IEnumerable<Transportadora>> GetAllAsync();
        Task<Transportadora> GetByIdAsync(int id);
        Task<Transportadora> AddAsync(Transportadora entity);
        Task UpdateAsync(Transportadora entity);
        Task DeleteAsync(int id);
    }
}