namespace SimpleCRUD_MVC.Business.Models.Output
{
    public class OrderItemOutput
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
