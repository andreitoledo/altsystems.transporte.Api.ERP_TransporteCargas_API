using System.Collections.Generic;
using System.Threading.Tasks;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<IEnumerable<Endereco>> ObterPorClienteAsync(int clienteId);
        Task<Endereco> ObterPorIdAsync(int id);
        Task<Endereco> AdicionarAsync(Endereco endereco);
        Task AtualizarAsync(int id, Endereco endereco);
        Task RemoverAsync(int id);
    }
}
