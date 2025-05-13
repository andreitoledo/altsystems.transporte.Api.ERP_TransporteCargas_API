namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Models
{
    public class Itinerario
    {
        public int Id { get; set; }
        public int ViagemId { get; set; }
        public string Local { get; set; }
        public DateTime HoraPrevista { get; set; }
        public Viagem Viagem { get; set; }
    }
}