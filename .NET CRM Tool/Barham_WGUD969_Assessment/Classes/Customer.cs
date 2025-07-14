using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Barham_WGUD969_Assessment.Classes
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; private set; }
        public Address Address { get; private set; }
        public int Active { get; private set; }
        public DateTime CreateDate { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime LastUpdate { get; private set; }
        public string LastUpdatedBy { get; private set; }


        // Constructor for modifying an existing customer
        public Customer(int customerID, string customerName, Address address, int active,
            DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdatedBy)
        {
            CustomerID = customerID;
            CustomerName = customerName;
            Address = address;
            Active = active;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdatedBy = lastUpdatedBy;
        }

        // Asynchronous factory method for adding a new customer
        public static Customer CreateNewCustomer(string customerName,
            Address address, int active, string createdBy, string lastUpdatedBy)
        {
            if (address == null)
            {
                address = new Address("Defualt", "Default", new City("Default", new Country("Default")), "00000",
                    "000000000");
            }

            return new Customer(-1, customerName, address, active, DateTime.Now, createdBy, DateTime.Now, createdBy);
        }
        
        // Asynchronous factory method for getting existing customer from database
        public static async Task<Customer> GetCustomerAsync(int customerId, User currentUser)
        {
            string query = "SELECT customerId, customerName, addressId, active, createDate, createdBy, " +
                "lastUpdate, lastUpdateBy FROM customer WHERE customerId = @CustomerId";
            Customer customer = null;
            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.connection))
            {
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                try
                {
                    if (DBConnection.connection.State != System.Data.ConnectionState.Open)
                    {
                        await DBConnection.connection.OpenAsync();
                    }
                    using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32("customerId");
                            string name = reader.GetString("customerName");
                            int addressId = reader.GetInt32("addressId");
                            int active = reader.GetInt32("active");
                            DateTime createDate = reader.GetDateTime("createDate");
                            string createdBy = reader.GetString("createdBy");
                            DateTime lastUpdate = DateTime.Now;
                            string lastUpdateBy = currentUser.UserName;
                            reader.Close();
                            Address address = await Address.GetAddressAsync(DBConnection.connection, addressId);
                            customer = new Customer(id, name, address, active, createDate, createdBy, lastUpdate, lastUpdateBy);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    if (DBConnection.connection.State == System.Data.ConnectionState.Open)
                    {
                        await DBConnection.connection.CloseAsync();
                    }
                }
            }
            return customer;
        }
    }
}
