using Microsoft.AspNetCore.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace barham_d424_ordermanagement.Models
{
    public class User : PersonBase
    {
        public int UserID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public int RoleID { get; set; }
        public UserRole Role { get; set; }

        public int FailedLoginAttempts { get; set; } = 0;
        public DateTime? LockoutEnd { get; set; } = null;
        public bool NewPassword { get; set; } = false;

        public void ResetPassword()
        {
            //set password to user specific phrase
            //get hash of password
            //set password hash to hash of password
            //set new password to true
        }
    }
}
