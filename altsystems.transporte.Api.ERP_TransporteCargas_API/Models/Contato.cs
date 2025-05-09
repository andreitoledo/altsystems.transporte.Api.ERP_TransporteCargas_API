using System.Text.Json.Serialization;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public int ClienteId { get; set; }

        [JsonIgnore] // isso aqui resolve o ciclo
        public Cliente Cliente { get; set; }



    }
}
