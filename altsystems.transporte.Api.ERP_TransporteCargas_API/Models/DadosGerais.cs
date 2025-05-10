namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Models
{
    public class DadosGerais
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }

        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public DateTime DataCadastro { get; set; }

        public Cliente Cliente { get; set; }
    }
}
