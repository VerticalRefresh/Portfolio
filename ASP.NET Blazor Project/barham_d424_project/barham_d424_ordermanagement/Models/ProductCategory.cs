using System.ComponentModel.DataAnnotations;

namespace barham_d424_ordermanagement.Models
{
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
