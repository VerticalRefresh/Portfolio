using System.ComponentModel.DataAnnotations;

namespace barham_d424_capstone.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public decimal  Price { get; set; }
        [Required]
        public int NumberPerOrder { get; set; }
        [Required]
        public int NumberInStock { get; set; }
        [Required]
        public string Description { get; set; }
        public int UserAddedID { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public int UserModifiedID { get; set; }
        [Required]
        public DateTime DateModified { get; set; }


    }
}
