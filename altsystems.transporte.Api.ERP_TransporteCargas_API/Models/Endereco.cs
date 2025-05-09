using System.Text.Json.Serialization;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public int ClienteId { get; set; }

        [JsonIgnore] // isso aqui resolve o ciclo
        public Cliente Cliente { get; set; }


    }
}
