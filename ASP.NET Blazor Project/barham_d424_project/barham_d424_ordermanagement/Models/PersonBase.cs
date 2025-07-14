using System.ComponentModel.DataAnnotations;

namespace barham_d424_ordermanagement.Models
{
    public abstract class PersonBase
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string Phone { get; set; }

        //Auditing
        public int UserAddedID { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserModifiedID { get; set; }
        public DateTime DateModified { get; set; }

    }
}
