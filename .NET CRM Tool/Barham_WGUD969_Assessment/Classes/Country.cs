using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Barham_WGUD969_Assessment.Classes
{
    public class Country
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        public Country(string countryName, int countryId = -1, DateTime createDate = default, string createdBy = null, DateTime lastUpdate = default, string lastUpdateBy = null)
        {
            CountryID = countryId;
            CountryName = countryName;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
        }

        // Get or add country to database
        public static async Task<Country> GetOrAddCountryAsync(MySqlConnection connection, string countryName, string userName)
        {
            Country country = null;
            string selectQuery = "SELECT countryId, country, createDate, createdBy, lastUpdate, lastUpdateBy FROM country WHERE country = @CountryName";
            string insertQuery = @"
                INSERT INTO country (country, createdBy, lastUpdateBy, createDate)
                VALUES (@CountryName, @UserName, @UserName, NOW());
                SELECT LAST_INSERT_ID();";

            using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, connection))
            {
                selectCmd.Parameters.AddWithValue("@CountryName", countryName);
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
                            int countryId = reader.GetInt32("countryId");
                            string name = reader.GetString("country");
                            DateTime createDate = reader.GetDateTime("createDate");
                            string createdBy = reader.GetString("createdBy");
                            DateTime lastUpdate = reader.GetDateTime("lastUpdate");
                            string lastUpdateBy = reader.GetString("lastUpdateBy");
                            reader.Close();

                            country = new Country(name, countryId, createDate, createdBy, lastUpdate, lastUpdateBy);
                        }

                    }

                    if (country == null)
                    {
                        using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@CountryName", countryName);
                            insertCmd.Parameters.AddWithValue("@UserName", userName);

                            int newCountryId = Convert.ToInt32(await insertCmd.ExecuteScalarAsync());
                            country = new Country(countryName, newCountryId);
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

            return country;
        }
        // Get country from database
        public static async Task<Country> GetCountryAsync(MySqlConnection connection, int countryId)
        {
            string query = "SELECT countryId, country, createDate, createdBy, lastUpdate, lastUpdateBy FROM country WHERE countryId = @CountryId";
            Country country = null;
            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.connection))
            {
                cmd.Parameters.AddWithValue("@CountryId", countryId);
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
                            int id = reader.GetInt32("countryId");
                            string countryName = reader.GetString("country");
                            DateTime createDate = reader.GetDateTime("createDate");
                            string createdBy = reader.GetString("createdBy");
                            DateTime lastUpdate = reader.GetDateTime("lastUpdate");
                            string lastUpdateBy = reader.GetString("lastUpdateBy");

                            reader.Close();
                            country = new Country(countryName, id, createDate, createdBy, lastUpdate, lastUpdateBy);
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

                return country;
            }
        }
    }
}
