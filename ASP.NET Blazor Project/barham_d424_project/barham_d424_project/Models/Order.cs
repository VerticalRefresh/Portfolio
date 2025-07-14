using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace barham_d424_ordermanagement.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public Address ShippingAddress { get; set; }
        [Precision (10, 2)]
        public decimal OrderTotal { get; set; }
        [Precision(10, 2)]
        public decimal AmountPaid { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string OrderStatus { get; set; }
    }
}
