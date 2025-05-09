namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public ICollection<Endereco> Enderecos { get; set; }
        public ICollection<Contato> Contatos { get; set; }
    }

}
