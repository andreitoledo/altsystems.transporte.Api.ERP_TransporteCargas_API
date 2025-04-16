namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Models
{
    public class Transportadora
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Contato { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;  // Data de cadastro da transportadora
    }

}
