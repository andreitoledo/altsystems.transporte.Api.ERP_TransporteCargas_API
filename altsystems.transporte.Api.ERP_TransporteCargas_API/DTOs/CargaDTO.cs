namespace altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs
{
    public class CargaDTO
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public decimal Peso { get; set; }      
        public decimal Volume { get; set; }    
        public DateTime DataColeta { get; set; }
        public DateTime DataEntrega { get; set; }
        public string Status { get; set; }
        public int IdCliente { get; set; }
    }
}