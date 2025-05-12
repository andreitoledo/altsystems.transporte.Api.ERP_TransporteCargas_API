namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string? Renavam { get; set; }
        public string? Chassi { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }

        public string Tipo { get; set; }
        public int Capacidade { get; set; }
        public int Ano { get; set; }


        public int? AnoFabricacao { get; set; }
        public int? AnoModelo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}