using System.ComponentModel.DataAnnotations;

namespace barham_d424_capstone.Models
{
    public class UserRole
    {
        [Key]
        public int RoleID { get; set; }

        [Required]
        public string RoleName { get; set; }

        public List<User> Users { get; set; }
    }
}
