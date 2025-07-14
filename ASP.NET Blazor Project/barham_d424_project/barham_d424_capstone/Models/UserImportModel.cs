using System.ComponentModel.DataAnnotations;

namespace barham_d424_capstone.Models
{
    public class UserImportModel
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public int RoleID { get; set; }


    }
}
