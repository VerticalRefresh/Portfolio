using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Barham_WGUD969_Assessment.Classes
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public Customer Customer { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Type { get; set; }
        public string URL { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdatedBy { get; set; }

        // Constructor for modifying an existing appointment
        public Appointment(int appointmentID, Customer customer, User user, string title, string description, string location,
            string contact, string type, string url, DateTime start, DateTime end,
            DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdatedBy)
        {
            AppointmentID = appointmentID;
            Customer = customer;
            User = user;
            Title = title;
            Description = description;
            Location = location;
            Contact = contact;
            Type = type;
            URL = url;
            Start = start;
            End = end;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdatedBy = lastUpdatedBy;
        }
        // Factory method for creating a new appointment
        public static Appointment CreateNewAppointment(Customer customer, User user)
        {
            Appointment appointment = new Appointment(-1, customer, user, "", "", "", "", "", "", DateTime.Now, DateTime.Now,
                DateTime.Now, "", DateTime.Now, "");
            return appointment;
        }

        // Asynchronous method to get appointment from database
        public static async Task<Appointment> GetAppointmentAsync(int appointmentId, User currentUser, int selectedCustomer)
        {
            string query = "SELECT * FROM appointment WHERE appointmentId = @AppointmentId";
            Appointment appointment = null;
            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.connection))
            {
                cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);
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
                            int id = reader.GetInt32("appointmentId");
                            int custId = reader.GetInt32("customerId");
                            int userId = reader.GetInt32("userId");
                            string title = reader.GetString("title");
                            string description = reader.GetString("description");
                            string location = reader.GetString("location");
                            string contact = reader.GetString("contact");
                            string type = reader.GetString("type");
                            string url = reader.GetString("url");
                            DateTime start = reader.GetDateTime("start").ToLocalTime();
                            DateTime end = reader.GetDateTime("end").ToLocalTime();
                            DateTime createDate = reader.GetDateTime("createDate");
                            string createdBy = reader.GetString("createdBy");
                            DateTime lastUpdate = reader.GetDateTime("lastUpdate");
                            string lastUpdateBy = reader.GetString("lastUpdateBy");
                            reader.Close();
                            Customer customer = await Customer.GetCustomerAsync(selectedCustomer, currentUser);
                            appointment = new Appointment(id, customer, currentUser, title, description, location,
                                contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy);
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
            return appointment;
        }
    }
}
