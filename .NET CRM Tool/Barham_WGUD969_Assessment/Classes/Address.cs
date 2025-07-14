using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Barham_WGUD969_Assessment.Classes
{
    public class Address
    {
        public int AddressID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public City City { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        // Constructor
        public Address(string addressLine1, string addressLine2, City city, string postalCode, string phone, int addressId = -1, DateTime createDate = default, string createdBy = "", DateTime lastUpdate = default, string lastUpdateBy = "")
        {
            AddressID = addressId;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            PostalCode = postalCode;
            Phone = phone;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
        }
        // Get or add address for construction of new customer
        public static async Task<Address> GetOrAddAddressAsync(MySqlConnection connection, string addressLine1, string addressLine2, City city, string postalCode, string phone, string userName)
        {
            Address address = null;
            string selectQuery = "SELECT addressId, address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy FROM address WHERE address = @AddressLine1 AND address2 = @AddressLine2 AND cityId = @CityId AND postalCode = @PostalCode AND phone = @Phone";
            string insertQuery = @"
                INSERT INTO address (address, address2, cityId, postalCode, phone, createdBy, lastUpdateBy, createDate)
                VALUES (@AddressLine1, @AddressLine2, @CityId, @PostalCode, @Phone, @UserName, @UserName, NOW());
                SELECT LAST_INSERT_ID();";

            using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, connection))
            {
                selectCmd.Parameters.AddWithValue("@AddressLine1", addressLine1);
                selectCmd.Parameters.AddWithValue("@AddressLine2", addressLine2);
                selectCmd.Parameters.AddWithValue("@CityId", city.CityID);
                selectCmd.Parameters.AddWithValue("@PostalCode", postalCode);
                selectCmd.Parameters.AddWithValue("@Phone", phone);
                try
                {
                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        await connection.OpenAsync();
                    }

                    using (MySqlDataReader reader = (MySqlDataReader)await selectCmd.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            int addressId = reader.GetInt32("addressId");
                            string addr1 = reader.GetString("address");
                            string addr2 = reader.GetString("address2");
                            DateTime createDate = reader.GetDateTime("createDate");
                            string createdBy = reader.GetString("createdBy");
                            DateTime lastUpdate = reader.GetDateTime("lastUpdate");
                            string lastUpdateBy = reader.GetString("lastUpdateBy");

                            address = new Address(addr1, addr2, city, postalCode, phone, addressId);
                        }
                    }

                    if (address == null)
                    {
                        using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@AddressLine1", addressLine1);
                            insertCmd.Parameters.AddWithValue("@AddressLine2", addressLine2);
                            insertCmd.Parameters.AddWithValue("@CityId", city.CityID);
                            insertCmd.Parameters.AddWithValue("@PostalCode", postalCode);
                            insertCmd.Parameters.AddWithValue("@Phone", phone);
                            insertCmd.Parameters.AddWithValue("@UserName", userName);

                            int newAddressId = Convert.ToInt32(await insertCmd.ExecuteScalarAsync());
                            address = new Address(addressLine1, addressLine2, city, postalCode, phone, newAddressId);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        await connection.CloseAsync();
                    }
                }
            }

            return address;
        }
        // Get address by ID
        public static async Task<Address> GetAddressAsync(MySqlConnection connection, int addressId)
        {
            string query = "SELECT addressId, address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy " +
                "FROM address WHERE addressId = @AddressId";
            Address address = null;
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AddressId", addressId);

                try
                {
                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        await DBConnection.connection.OpenAsync();
                    }
                    using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32("addressId");
                            string address1 = reader.GetString("address");
                            string address2 = reader.GetString("address2");
                            int cityId = reader.GetInt32("cityId");
                            string postalCode = reader.GetString("postalCode");
                            string phone = reader.GetString("phone");
                            DateTime createDate = reader.GetDateTime("createDate");
                            string createdBy = reader.GetString("createdBy");
                            DateTime lastUpdate = reader.GetDateTime("lastUpdate");
                            string lastUpdateBy = reader.GetString("lastUpdateBy");
                            reader.Close();


                            City city = await City.GetCityAsync(DBConnection.connection, cityId);

                            address = new Address(address1, address2, city, postalCode, phone, addressId, createDate, createdBy, lastUpdate, lastUpdateBy);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (DBConnection.connection.State == System.Data.ConnectionState.Open)
                    {
                        await DBConnection.connection.CloseAsync();
                    }
                }
                return address;
            }
        }
    }
}
