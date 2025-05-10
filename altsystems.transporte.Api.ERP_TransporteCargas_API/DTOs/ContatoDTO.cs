namespace altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs
{
    public class ContatoDTO
    {
        public int Id { get; set; }             // necessário para edição e retorno
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int ClienteId { get; set; }      // necessário para manter a associação
    }
}