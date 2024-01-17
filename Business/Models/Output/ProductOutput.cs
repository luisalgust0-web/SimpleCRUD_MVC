using System.ComponentModel;

namespace SimpleCRUD_MVC.Business.Models.Output
{
    public class ProductOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("Image Product")]
        public byte[] ImageProduct { get; set; }
        public bool Disponibility { get; set; }
    }
}
