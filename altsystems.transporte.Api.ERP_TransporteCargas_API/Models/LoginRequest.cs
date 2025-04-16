using System.Text.Json.Serialization;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Models
{
    public class LoginRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("senha")]
        public string Senha { get; set; }
    }
}
