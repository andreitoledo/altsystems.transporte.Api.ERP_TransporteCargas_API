using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs
{
    public class ViagemDTO
    {
        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataChegada { get; set; }

        public int VeiculoId { get; set; }
        public int MotoristaId { get; set; }

        public Veiculo? Veiculo { get; set; }
        public Motorista? Motorista { get; set; }


    }
}
