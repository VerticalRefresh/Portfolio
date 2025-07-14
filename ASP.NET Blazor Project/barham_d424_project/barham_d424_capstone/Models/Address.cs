using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace barham_d424_capstone.Models
{
    [Owned]
    public class Address
    {
        [Required(ErrorMessage = "Address line 1 is required"), MaxLength(100, ErrorMessage = "Address line 1 cannot be longer than 100 characters")]
        public string Address1 { get; set; }
        [MaxLength(100, ErrorMessage = "Address line 2 cannot be longer than 100 characters")]
        public string Address2 { get; set; } = string.Empty;
        [Required(ErrorMessage = "City is required"), MaxLength(50, ErrorMessage = "City cannot be longer than 50 characters")]
        public string City { get; set; }
        [Required, MaxLength(2, ErrorMessage = "Enter 2 character state code")]
        public string StateCode { get; set; }
        [Required, MaxLength(10, ErrorMessage = "Postal code cannot be longer than 10 characters")]
        public string ZipCode { get; set; }
        [MaxLength(50, ErrorMessage = "Country cannot be longer than 50 characters")]
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
    }
}
