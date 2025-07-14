using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

//Class to hold user data for logged in user, potential for use in application expansion for
//assigning appointments to users other than the one logged in

namespace Barham_WGUD969_Assessment.Classes
{
    public class User
    {
        public int UserID { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public int Active { get; private set; }
        public DateTime CreateDate { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime LastUpdate { get; private set; }
        public string LastUpdatedBy { get; private set; }

        public User(int UserID, string UserName, string Password, int Active, DateTime CreateDate, string CreatedBy, DateTime LastUpdate, string LastUpdatedBy)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.Password = Password;
            this.Active = Active;
            this.CreateDate = CreateDate;
            this.CreatedBy = CreatedBy;
            this.LastUpdate = LastUpdate;
            this.LastUpdatedBy = LastUpdatedBy;
        }
    }
}
