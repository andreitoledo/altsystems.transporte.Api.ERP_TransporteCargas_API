namespace altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs
{
    public class DadosGeraisDTO
    {
        public int Id { get; set; }
        public string? RamoAtividade { get; set; }
        public string? Observacoes { get; set; }
        public string? TipoCadastro { get; set; }
        public bool StatusCadastro { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
