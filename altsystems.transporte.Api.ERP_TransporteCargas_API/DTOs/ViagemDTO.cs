namespace altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs
{
    public class ViagemDTO
    {
        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataChegada { get; set; }
    }
}
