using System.ComponentModel;

namespace SimpleCRUD_MVC.Business.Models.Output
{
    public class OrderOutput
    {
        public int Id { get; set; }
        [DisplayName("Client Id")]
        public int ClientId { get; set; }
        [DisplayName("Client First Name")]
        public string ClientFirstName { get; set; }
        [DisplayName("Client Last Name")]
        public string ClientLastName { get; set; }
    }
}
