using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUDWithRepository.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}