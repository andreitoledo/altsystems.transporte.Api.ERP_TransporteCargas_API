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
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<DadosGerais> DadosGerais { get; set; }
        public DbSet<ClienteCnpj> ClienteCnpjs { get; set; }
        public DbSet<InscricaoEstadual> InscricoesEstaduais { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Viagem> Viagens { get; set; }
        public DbSet<Itinerario> Itinerarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Enderecos)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.ClienteId);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Contatos)
                .WithOne(ct => ct.Cliente)
                .HasForeignKey(ct => ct.ClienteId);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.DadosGerais)
                .WithOne(ct => ct.Cliente)
                .HasForeignKey(ct => ct.ClienteId);

            // CNPJ - relação 1:1
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Cnpj)
                .WithOne(cc => cc.Cliente)
                .HasForeignKey<ClienteCnpj>(cc => cc.ClienteId);

            // Inscrições Estaduais - relação 1:N
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.InscricoesEstaduais)
                .WithOne(ie => ie.Cliente)
                .HasForeignKey(ie => ie.ClienteId);


            modelBuilder.Entity<Viagem>()
                .HasMany(v => v.Itinerarios)
                .WithOne(i => i.Viagem)
                .HasForeignKey(i => i.ViagemId);

            modelBuilder.Entity<Itinerario>()
                .HasIndex(i => i.ViagemId);


        }

    }

}
