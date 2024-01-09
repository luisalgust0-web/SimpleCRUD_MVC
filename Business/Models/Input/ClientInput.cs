using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleCRUD_MVC.Business.Models.Input
{
    public class ClientInput
    {
        public int? Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
