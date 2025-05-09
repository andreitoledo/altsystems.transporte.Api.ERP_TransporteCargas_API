namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Tipo { get; set; }
        public int Capacidade { get; set; }
        public int Ano { get; set; }

        // Definir o valor automaticamente ao criar o veículo
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public string Modelo { get; set; }
    }
}
