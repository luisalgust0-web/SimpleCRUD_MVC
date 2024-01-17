using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCRUD_MVC.Business.Models.Input
{
    public class OrderItemInput
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        [DisplayName("Order Id")]
        [Required]
        public int OrderId { get; set; }
        [DisplayName("Product Id")]
        [Required]
        public int ProductId { get; set; }
        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }
    }
}
