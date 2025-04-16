namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
        public string Role { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
