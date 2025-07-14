using System.ComponentModel.DataAnnotations;

namespace barham_d424_capstone.Models
{
    public class ProductClass
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
