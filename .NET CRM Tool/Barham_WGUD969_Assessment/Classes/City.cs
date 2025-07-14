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
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public Country Country { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }
        
        //constructor
        public City(string cityName, Country country, int cityId = -1, DateTime createDate = default, string createdBy = "", DateTime lastUpdate = default, string lastUpdateBy = "")
        {
            CityID = cityId;
            CityName = cityName;
            Country = country;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
        }
        // Get or add city to database
        public static async Task<City> GetOrAddCityAsync(MySqlConnection connection, string cityName, Country country, string userName)
        {
            City city = null;
            string selectQuery = "SELECT cityId, city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy FROM city WHERE city = @CityName AND countryId = @CountryId";
            string insertQuery = @"
                INSERT INTO city (city, countryId, createdBy, lastUpdateBy, createDate)
                VALUES (@CityName, @CountryId, @UserName, @UserName, NOW());
                SELECT LAST_INSERT_ID();";

            using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, connection))
            {
                selectCmd.Parameters.AddWithValue("@CityName", cityName);
                selectCmd.Parameters.AddWithValue("@CountryId", country.CountryID);
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
                            int cityId = reader.GetInt32("cityId");
                            string name = reader.GetString("city");
                            DateTime createDate = reader.GetDateTime("createDate");
                            string createdBy = reader.GetString("createdBy");
                            DateTime lastUpdate = reader.GetDateTime("lastUpdate");
                            string lastUpdateBy = reader.GetString("lastUpdateBy");

                            city = new City(name, country, cityId);
                        }
                    }

                    if (city == null)
                    {
                        using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@CityName", cityName);
                            insertCmd.Parameters.AddWithValue("@CountryId", country.CountryID);
                            insertCmd.Parameters.AddWithValue("@UserName", userName);

                            int newCityId = Convert.ToInt32(await insertCmd.ExecuteScalarAsync());
                            city = new City(cityName, country, newCityId);
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

            return city;
        }
        // Get city from database
        public static async Task<City> GetCityAsync(MySqlConnection connection, int cityId)
        {
            string query = "SELECT cityId, city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy " +
                "FROM city WHERE cityId = @CityId";
            City city = null;
            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.connection))
            {
                cmd.Parameters.AddWithValue("@CityId", cityId);
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
                            int id = reader.GetInt32("cityId");
                            string cityName = reader.GetString("city");
                            int countryId = reader.GetInt32("countryId");
                            DateTime createDate = reader.GetDateTime("createDate");
                            string createdBy = reader.GetString("createdBy");
                            DateTime lastUpdate = reader.GetDateTime("lastUpdate");
                            string lastUpdateBy = reader.GetString("lastUpdateBy");
                            reader.Close();



                            Country country = await Country.GetCountryAsync(DBConnection.connection, countryId);
                            city = new City(cityName, country, cityId, createDate, createdBy, lastUpdate, lastUpdateBy);
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
                return city;
            }
        }
    }
}
