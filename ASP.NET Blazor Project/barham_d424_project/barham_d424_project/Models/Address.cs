using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace barham_d424_ordermanagement.Models
{
    [Owned]
    public class Address
    {
        [Required, MaxLength(100)]
        public string Address1 { get; set; }
        [MaxLength(100)]
        public string Address2 { get; set; }
        [Required, MaxLength(50)]
        public string City { get; set; }
        [MaxLength(2)]
        public string StateCode { get; set; }
        [MaxLength(10)]
        public string ZipCode { get; set; }
        [MaxLength(50)]
        [Required]
        public string Country { get; set; }
    }
}
