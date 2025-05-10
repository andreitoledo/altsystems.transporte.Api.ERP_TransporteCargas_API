namespace altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs
{
    public class EnderecoDTO
    {
        public int Id { get; set; }           // necessário para retorno e PUT
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int ClienteId { get; set; }    // necessário para associar ao cliente
    }
}