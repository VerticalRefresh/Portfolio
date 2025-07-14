using System.ComponentModel.DataAnnotations;

namespace barham_d424_ordermanagement.Models
{
    public class ProductClass
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
