using System.ComponentModel.DataAnnotations;

namespace barham_d424_capstone.Models
{
    public class ProductImportModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int NumberPerOrder { get; set; }
        [Required]
        public int NumberInStock { get; set; } 
        [Required]
        public string Description { get; set; }

    }
}
