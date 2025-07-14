using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace barham_d424_ordermanagement.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
        [Required]
        public int ProductID { get; set; }
        public Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required, Precision(10, 2)]
        public decimal PriceAtOrder { get; set; }
    }
}
