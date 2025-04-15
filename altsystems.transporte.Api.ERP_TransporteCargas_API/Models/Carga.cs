namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Models
{
    public class Carga
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Peso { get; set; }
        public decimal Volume { get; set; }
        public DateTime DataColeta { get; set; }
        public DateTime DataEntrega { get; set; }
        public string Status { get; set; }
        public int IdCliente { get; set; }
    }

}
