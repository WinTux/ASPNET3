using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNET3.Models
{
    [Table("producto")]
    public class ProductoDDBB
    {
        [Key]
        [Column("id_prod")]
        [Required]
        public int idProd { get; set; }
        [MaxLength(20)]
        public string nombre { get; set; }
        [Range(1,1999)]
        public int precio { get; set; }
    }
}
