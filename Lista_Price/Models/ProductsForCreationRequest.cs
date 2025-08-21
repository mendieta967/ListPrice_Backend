using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lista_Price.Models
{
    public class ProductsForCreationRequest
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

    }
}
