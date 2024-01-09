using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCRUD_MVC.Business.Models.Input
{
    public class ProductInput
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [NotMapped]
        public IFormFile Image { get; set; }
        public bool Disponibility { get; set; }
    }
}
