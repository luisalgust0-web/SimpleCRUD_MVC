namespace SimpleCRUD_MVC.Business.Models.Input
{
    public class OrderItemInput
    {
        public int? Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
