namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Models
{
    public class DadosGerais
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }

        public string? RamoAtividade { get; set; }
        public string? Observacoes { get; set; }
        public string? TipoCadastro { get; set; }
        public bool StatusCadastro { get; set; }

        public DateTime DataCadastro { get; set; }

        public Cliente Cliente { get; set; }
    }
}
