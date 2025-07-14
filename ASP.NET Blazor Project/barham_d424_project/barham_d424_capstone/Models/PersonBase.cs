using System.ComponentModel.DataAnnotations;

namespace barham_d424_capstone.Models
{
    public abstract class PersonBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }

        [Required, EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required, Phone(ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }

        //Auditing
        public int UserAddedID { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserModifiedID { get; set; }
        public DateTime DateModified { get; set; }

    }
}
