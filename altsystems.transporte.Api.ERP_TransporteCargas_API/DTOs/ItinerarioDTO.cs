namespace altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs
{
    public class ItinerarioDTO
    {
        public int Id { get; set; }
        public int ViagemId { get; set; }
        public string Local { get; set; }
        public DateTime HoraPrevista { get; set; }
    }
}
