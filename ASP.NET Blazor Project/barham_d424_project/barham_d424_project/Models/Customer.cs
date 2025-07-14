using System.ComponentModel.DataAnnotations;

namespace barham_d424_ordermanagement.Models
{
    public class Customer : PersonBase
    {
        [Key]
        public int CustomerId { get; set; }
        public Address Address { get; set; }

    }
}
