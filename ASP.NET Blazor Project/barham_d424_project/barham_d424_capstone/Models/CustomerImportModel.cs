using System.ComponentModel.DataAnnotations;

namespace barham_d424_capstone.Models
{
    public class CustomerImportModel
    {
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string StateCode { get; set; }
        [Required]
        [RegularExpression(@"\d{5}", ErrorMessage = "ZipCode must be 5 digits")]
        public string ZipCode { get; set; }
        [Required]
        public string Country { get; set; }

    }
}
