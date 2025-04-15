namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Models
{
    public class PedidoTransporte
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdCarga { get; set; }
        public int IdVeiculo { get; set; }
        public string Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataPrevisaoEntrega { get; set; }
    }

}
