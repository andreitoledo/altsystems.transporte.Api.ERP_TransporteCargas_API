using System.Text.Json.Serialization;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs
{
    public class MotoristaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string CNH { get; set; }
        public string Categoria { get; set; }
        [JsonPropertyName("validadeCnh")]
        public DateTime? ValidadeCNH { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public bool Ativo { get; set; }
    }
}