namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Data
{
    using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
    using Microsoft.EntityFrameworkCore;

    public class ERPContext : DbContext
    {
        public ERPContext(DbContextOptions<ERPContext> options) : base(options) { }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Carga> Cargas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Transportadora> Transportadoras { get; set; }
        public DbSet<PedidoTransporte> PedidosTransporte { get; set; }
        public DbSet<RelatorioFinanceiro> RelatoriosFinanceiros { get; set; }
    }

}
