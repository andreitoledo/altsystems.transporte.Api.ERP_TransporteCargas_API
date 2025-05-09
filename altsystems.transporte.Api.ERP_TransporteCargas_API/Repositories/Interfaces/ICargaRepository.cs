using System.Collections.Generic;
using System.Threading.Tasks;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces
{
    public interface ICargaRepository
    {
        Task<IEnumerable<Carga>> GetAllAsync();
        Task<Carga> GetByIdAsync(int id);
        Task<Carga> AddAsync(Carga entity);
        Task UpdateAsync(Carga entity);
        Task DeleteAsync(int id);
    }
}