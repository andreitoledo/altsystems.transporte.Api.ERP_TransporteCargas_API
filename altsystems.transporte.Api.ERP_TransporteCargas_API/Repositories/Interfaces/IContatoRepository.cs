using System.Collections.Generic;
using System.Threading.Tasks;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces
{
    public interface IContatoRepository
    {
        Task<IEnumerable<Contato>> ObterPorClienteAsync(int clienteId);
        Task<Contato> ObterPorIdAsync(int id);
        Task<Contato> AdicionarAsync(Contato contato);
        Task AtualizarAsync(int id, Contato contato);
        Task RemoverAsync(int id);
    }
}
