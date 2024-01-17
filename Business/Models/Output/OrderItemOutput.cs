using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleCRUD_MVC.Business.Models.Output
{
    public class OrderItemOutput
    {
        public int Id { get; set; }
        [DisplayName("Order Id")]
        public int OrderId { get; set; }
        [DisplayName("Client Name")]
        public string ClientName { get; set; }
        [DisplayName("Product Id")]
        public int ProductId { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
