namespace altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs
{
    public class VeiculoDTO
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }
        public int Capacidade { get; set; } 
        public int Ano { get; set; }
        public DateTime DataCadastro { get; set; } 
    }
}