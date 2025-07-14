using MySql.Data.MySqlClient;
using System.Windows.Forms;


//Establishes connection for use throughout application.  
namespace Barham_WGUD969_Assessment.Classes
{
    public static class DBConnection
    {
        public static MySqlConnection connection { get; set; }


        /// Opens connection to database
        public static void startConnection()
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //Closes connection to database
        public static void stopConnection()
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                }
                connection = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }
    }
}
