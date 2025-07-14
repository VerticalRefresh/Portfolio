using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Barham_WGUD969_Assessment.Classes;
using MySql.Data.MySqlClient;

namespace Barham_WGUD969_Assessment.Windows
{
    public partial class AppointmentForm : Form
    {
        MainPage mainPage;
        Appointment formAppointment;
        
        //constructor
        public AppointmentForm(MainPage mainpage, Appointment appointment)
        {
            InitializeComponent();
            mainPage = mainpage;
            formAppointment = appointment;
            StartPicker.Format = DateTimePickerFormat.Custom;
            StartPicker.CustomFormat = "MM/dd/yyyy HH:mm tt";
            StartPicker.ShowUpDown = false;
            EndPicker.Format = DateTimePickerFormat.Custom;
            EndPicker.CustomFormat = "MM/dd/yyyy HH:mm tt";
            EndPicker.ShowUpDown = false;
            this.Controls.Add(StartPicker);

            if (appointment.AppointmentID < 0)
            {
                ApptIdBox.Text = "New Appointment";
            }
            else
            {
                ApptIdBox.Text = appointment.AppointmentID.ToString();
            }
        }
        //save new or overwrite appointment
        private async void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                TrimFields();
                int apptId;
                DateTime createDate;
                DateTime lastUpdate;

                if (DBConnection.connection.State != ConnectionState.Open)
                {
                    await DBConnection.connection.OpenAsync();
                }
                if (await IsOverlappingAppointment(DBConnection.connection, formAppointment.User.UserID,
                    StartPicker.Value, EndPicker.Value))
                {
                    MessageBox.Show("Appointment Time Overlaps with Existing Appointment");
                    return;
                }

                if (ApptIdBox.Text == "New Appointment")
                {
                    apptId = -1;
                    createDate = DateTime.Now;
                    lastUpdate = DateTime.Now;
                }
                else
                {
                    apptId = Convert.ToInt32(ApptIdBox.Text);
                    createDate = formAppointment.CreateDate;
                    lastUpdate = DateTime.Now;
                }
                string title = TitleBox.Text;
                string description = DescriptionBox.Text;
                string location = LocationBox.Text;
                string contact = ContactBox.Text;
                string type = TypeBox.Text;
                string url = UrlBox.Text;
                DateTime start = StartPicker.Value;
                DateTime end = EndPicker.Value;
                string createdBy = UserNameBox.Text;
                string updatedBy = UserNameBox.Text;
                Appointment appointment = new Appointment(apptId, formAppointment.Customer, formAppointment.User,
                       title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, updatedBy);
                await InsertOrUpdateAppointmentAsync(DBConnection.connection, appointment);
                MessageBox.Show("Appointment Saved Successfully");
                mainPage.RefreshData();
                mainPage.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //check for overlapping appointments
        private async Task<bool> IsOverlappingAppointment(MySqlConnection connection, int userId, DateTime start, DateTime end)
        {
            string query = @"
                SELECT *
                FROM appointment
                WHERE userId = @UserID
                AND (
                    (@Start < end AND @End > start)
                    OR
                    (@Start < start AND @End > end)
                    )";
            if (connection.State != System.Data.ConnectionState.Open)
            {
                await connection.OpenAsync();
            }
            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.connection))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@Start", start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@End", end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                try
                {
                    using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                    {
                        return reader.HasRows;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return true;
                }
            }
        }
        //validate business hours
        private bool IsValidBusinessHours(DateTime start, DateTime end)
        {
            TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            if (start.Date != end.Date)
            {
                return false;
            }
            if (start.DayOfWeek == DayOfWeek.Saturday || start.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }
            TimeSpan startOfBusiness = new TimeSpan(8, 0, 0);
            TimeSpan endOfBusiness = new TimeSpan(17, 0, 0);

            if (start.TimeOfDay < startOfBusiness || end.TimeOfDay > endOfBusiness)
            {
                return false;
            }
            return true;
        }

        //insert or update appointment in DB
        private async Task InsertOrUpdateAppointmentAsync(MySqlConnection connection, Appointment appointment)
        {
            string insertQuery = @"
                INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy)
                VALUES (@CustomerId, @UserId, @Title, @Description, @Location, @Contact, @Type, @Url, @Start, @End, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdateBy)";
            string updateQuery = @"
                UPDATE appointment
                SET customerId = @CustomerId, userId = @UserId, title = @Title, description = @Description, location = @Location, contact = @Contact, type = @Type, 
                url = @Url, start = @Start, end = @End, createDate = @CreateDate, createdBy = @CreatedBy, lastUpdate = @LastUpdate, lastUpdateBy = @LastUpdateBy
                WHERE appointmentId = @AppointmentId";
            if (connection.State != System.Data.ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            using (MySqlCommand cmd = new MySqlCommand(appointment.AppointmentID == -1 ? insertQuery : updateQuery, DBConnection.connection))
            {
                cmd.Parameters.AddWithValue("@AppointmentId", appointment.AppointmentID);
                cmd.Parameters.AddWithValue("@UserId", appointment.User.UserID);
                cmd.Parameters.AddWithValue("@CustomerId", appointment.Customer.CustomerID);
                cmd.Parameters.AddWithValue("@Title", appointment.Title);
                cmd.Parameters.AddWithValue("@Description", appointment.Description);
                cmd.Parameters.AddWithValue("@Location", appointment.Location);
                cmd.Parameters.AddWithValue("@Contact", appointment.Contact);
                cmd.Parameters.AddWithValue("@Type", appointment.Type);
                cmd.Parameters.AddWithValue("@Url", appointment.URL);
                cmd.Parameters.AddWithValue("@Start", appointment.Start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@End", appointment.End.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@CreateDate", appointment.CreateDate.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@CreatedBy", appointment.CreatedBy);
                cmd.Parameters.AddWithValue("@LastUpdate", appointment.LastUpdate.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@LastUpdateBy", appointment.LastUpdatedBy);

                try
                {
                    await cmd.ExecuteNonQueryAsync();

                    if (appointment.AppointmentID == -1)
                    {
                        appointment.AppointmentID = (int)cmd.LastInsertedId;
                    }
                }
                catch (MySqlException ex)
                {
                    StringBuilder errorMessage = new StringBuilder();
                    errorMessage.AppendLine("Error Executing SQL Command");
                    errorMessage.AppendLine(cmd.CommandText);
                    foreach (MySqlParameter p in cmd.Parameters)
                    {
                        errorMessage.AppendLine($"{p.ParameterName} {p.Value}");
                    }
                    errorMessage.AppendLine($"Error Message: {ex.Message}");
                    MessageBox.Show(errorMessage.ToString());
                }
            }
        }

        private void TrimFields()
        {
            TitleBox.Text = TitleBox.Text.Trim();
            DescriptionBox.Text = DescriptionBox.Text.Trim();
            LocationBox.Text = LocationBox.Text.Trim();
            ContactBox.Text = ContactBox.Text.Trim();
            TypeBox.Text = TypeBox.Text.Trim();
            UrlBox.Text = UrlBox.Text.Trim();
        }
        //validate form fields on text change
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        //validate form fields
        private void ValidateFields()
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(TitleBox.Text))
            {
                TitleBox.BackColor = Color.Red;
                isValid = false;
                ErrorLabel.Text = "Title is required";
            }
            else
            {
                TitleBox.BackColor = Color.White;
            }
            if (string.IsNullOrWhiteSpace(DescriptionBox.Text))
            {
                DescriptionBox.BackColor = Color.Red;
                isValid = false;
                ErrorLabel.Text = "Description is required";
            }
            else
            {
                DescriptionBox.BackColor = Color.White;
            }
            if (string.IsNullOrWhiteSpace(LocationBox.Text))
            {
                LocationBox.BackColor = Color.Red;
                isValid = false;
                ErrorLabel.Text = "Location is required";
            }
            else
            {
                LocationBox.BackColor = Color.White;
            }
            if (string.IsNullOrWhiteSpace(ContactBox.Text))
            {
                ContactBox.BackColor = Color.Red;
                isValid = false;
                ErrorLabel.Text = "Contact is required";
            }
            else
            {
                ContactBox.BackColor = Color.White;
            }
            if (string.IsNullOrWhiteSpace(TypeBox.Text))
            {
                TypeBox.BackColor = Color.Red;
                isValid = false;
                ErrorLabel.Text = "Type is required";
            }
            else
            {
                TypeBox.BackColor = Color.White;
            }
            if (string.IsNullOrWhiteSpace(UrlBox.Text))
            {
                UrlBox.BackColor = Color.Red;
                isValid = false;
                ErrorLabel.Text = "URL is required";
            }
            else
            {
                UrlBox.BackColor = Color.White;
            }
            if (StartPicker.Value >= EndPicker.Value)
            {
                StartPicker.BackColor = Color.Red;
                EndPicker.BackColor = Color.Red;
                isValid = false;
                ErrorLabel.Text = "Start date must be before end date";
            }
            else
            {
                StartPicker.BackColor = Color.White;
                EndPicker.BackColor = Color.White;
            }
            if (!IsValidBusinessHours(StartPicker.Value, EndPicker.Value))
            {
                StartPicker.BackColor = Color.Red;
                EndPicker.BackColor = Color.Red;
                isValid = false;
                ErrorLabel.Text = "Appointments must be scheduled during business hours";
            }
            else
            {
                StartPicker.BackColor = Color.White;
                EndPicker.BackColor = Color.White;
            }
            ErrorLabel.Visible = !isValid;
            SaveButton.Enabled = isValid;
        }

        //cancel and return to main page
        private void CancelButton_Click(object sender, EventArgs e)
        {
            mainPage.Show();
            this.Close();
        }

        //populate form with appointment data
        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            UserIdBox.Text = formAppointment.User.UserID.ToString();
            CustIdBox.Text = formAppointment.Customer.CustomerID.ToString();
            CustomerNameBox.Text = formAppointment.Customer.CustomerName.ToString();
            UserNameBox.Text = formAppointment.User.UserName.ToString();
            TitleBox.Text = formAppointment.Title.ToString();
            DescriptionBox.Text = formAppointment.Description.ToString();
            LocationBox.Text = formAppointment.Location.ToString();
            ContactBox.Text = formAppointment.Contact.ToString();
            TypeBox.Text = formAppointment.Type.ToString();
            UrlBox.Text = formAppointment.URL.ToString();
            StartPicker.Value = formAppointment.Start;
            EndPicker.Value = formAppointment.End;
        }
    }
}
