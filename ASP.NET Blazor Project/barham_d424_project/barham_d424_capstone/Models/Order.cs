using barham_d424_capstone.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace barham_d424_capstone.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
        [Required]
        [ForeignKey("UserID")]
        public User User { get; set; }
        [Required]
        public Address ShippingAddress { get; set; }
        [Precision (10, 2)]
        public decimal OrderTotal { get; set; }
        [Precision(10, 2)]
        public decimal AmountPaid { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public OrderStatus Status { get; set; }
    }
    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }
}
