using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCRUD_MVC.Business.Models.Input
{
    public class OrderInput
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        [DisplayName("Client")]
        public int ClientId { get; set; }
    }
}
