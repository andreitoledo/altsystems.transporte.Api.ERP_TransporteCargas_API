using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Models
{
    public class ClienteCnpj
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(14)]
        public string Cnpj { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }
    }
}
