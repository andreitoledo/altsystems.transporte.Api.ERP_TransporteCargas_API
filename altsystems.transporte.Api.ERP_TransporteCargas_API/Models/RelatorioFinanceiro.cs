namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Models
{
    public class RelatorioFinanceiro
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public decimal Custo { get; set; }
        public decimal Receita { get; set; }
        public DateTime DataGeracao { get; set; }
    }

}
