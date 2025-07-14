using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using Barham_WGUD969_Assessment.Classes;
using MySql.Data.MySqlClient;

namespace Barham_WGUD969_Assessment.Windows
{
    public partial class MainPage : Form
    {
        DataSet dataSet;
        DataTable filteredTable;
        RadioButton previousApptSelection;
        private bool isHandlingCheckChanged = false;
        private User currentUser;
        int selectedAppointment;
        int selectedCustomer;

        public MainPage(User user)
        {
            InitializeComponent();
            currentUser = user;
            DataLoad();
            User15MinuteWarning();
        }

        // Load data from database
        private void DataLoad()
        {
            string custQuery = "SELECT * FROM customer";
            string apptQuery = "SELECT * FROM appointment";
            dataSet = new DataSet();

            using (MySqlDataAdapter custAdapter = new MySqlDataAdapter(custQuery, DBConnection.connection))
            {
                try
                {
                    custAdapter.Fill(dataSet, "customer");
                    CustomerView.AutoGenerateColumns = false;
                    CustomerView.Columns.Clear();
                    CustomerView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "customerId",
                        HeaderText = "Customer ID",
                        Name = "customerId"
                    });
                    CustomerView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "customerName",
                        HeaderText = "Customer Name",
                        Name = "customerName"
                    });
                    CustomerView.DataSource = dataSet.Tables["customer"];
                    CustomerView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    CustomerView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            using (MySqlDataAdapter apptAdapter = new MySqlDataAdapter(apptQuery, DBConnection.connection))
            {
                try
                {
                    apptAdapter.Fill(dataSet, "appointment");
                    AppointmentView.AutoGenerateColumns = false;
                    AppointmentView.Columns.Clear();
                    AppointmentView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "appointmentId",
                        HeaderText = "ID",
                        Name = "appointmentId"
                    });
                    AppointmentView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "customerId",
                        HeaderText = "Cust. ID"
                    });
                    AppointmentView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "start",
                        HeaderText = "Start Time",
                        DefaultCellStyle = new DataGridViewCellStyle { Format = "MM/dd/yyyy hh:mm tt" }
                    });
                    AppointmentView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "end",
                        HeaderText = "End Time",
                        DefaultCellStyle = new DataGridViewCellStyle { Format = "MM/dd/yyyy hh:mm tt" }
                    });
                    AppointmentView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "type",
                        HeaderText = "Type"
                    });
                    AppointmentView.DataSource = dataSet.Tables["appointment"];
                    AppointmentView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    AppointmentView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    foreach (DataRow row in dataSet.Tables["appointment"].Rows)
                    {
                        DateTime startUTC = Convert.ToDateTime(row["start"]);
                        DateTime endUTC = Convert.ToDateTime(row["end"]);
                        DateTime startLocal = startUTC.ToLocalTime();
                        DateTime endLocal = endUTC.ToLocalTime();
                        row["start"] = startLocal;
                        row["end"] = endLocal;
                    }


                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            CustomerView.ClearSelection();
            if (CustomerView.Rows.Count > 0)
            {
                CustomerView.Rows[0].Selected = true;
                selectedCustomer = Convert.ToInt32(CustomerView.Rows[0].Cells[0].Value);
            }
            previousApptSelection = DayRdoButton;
        }

        // Update the calendar view based on the selected radio button
        private void UpdateCalendarSelection()
        {
            DateTime selectedDate = CalendarView.SelectionStart;

            if (DayRdoButton.Checked)
            {
                CalendarView.BoldedDates = new DateTime[] { };
                CalendarView.SelectionRange = new SelectionRange(selectedDate, selectedDate);
                previousApptSelection = DayRdoButton;
            }
            else if (WeekRdoButton.Checked)
            {
                CalendarView.BoldedDates = new DateTime[] { };
                int diff = (7 + (selectedDate.DayOfWeek - DayOfWeek.Sunday)) % 7;
                DateTime startOfWeek = selectedDate.AddDays(-1 * diff).Date;
                DateTime endOfWeek = startOfWeek.AddDays(6);
                CalendarView.SelectionRange = new SelectionRange(startOfWeek, endOfWeek);
                previousApptSelection = WeekRdoButton;
            }
            else if (MonthRdoButton.Checked)
            {
                DateTime startOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1);
                DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
                CalendarView.SelectionRange = new SelectionRange(startOfMonth, startOfMonth);
                CalendarView.BoldedDates = new DateTime[] { };
                for (DateTime date = startOfMonth; date <= endOfMonth; date = date.AddDays(1))
                {
                    CalendarView.AddBoldedDate(date);
                }
                CalendarView.Tag = new Tuple<DateTime, DateTime>(startOfMonth, endOfMonth);
                CalendarView.UpdateBoldedDates();
                previousApptSelection = MonthRdoButton;
            }
            UpdateAppointmentView();
        }

        //filters appointmentview base on radio button selection
        private void UpdateAppointmentView()
        {
            DateTime startRange;
            DateTime endRange;
            if (MonthRdoButton.Checked)
            {
                DateTime selectedDate = CalendarView.SelectionStart;
                startRange = new DateTime(selectedDate.Year, selectedDate.Month, 1);
                endRange = startRange.AddMonths(1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);
                SortApptByTime(startRange, endRange);
            }
            else if (CustRdoButton.Checked)
            {
                if (CustomerView.SelectedRows.Count == 0)
                {
                    Debug.WriteLine("UpdatedAppointmentView: No customer selected.");
                    MessageBox.Show("Please select a customer.");
                    previousApptSelection.Checked = true;
                    return;
                }
                try
                {
                    int selectedID = Convert.ToInt32(CustomerView.SelectedRows[0].Cells[0].Value);
                    SortByCustomer(selectedID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex}");
                }
            }
            else
            {
                startRange = CalendarView.SelectionRange.Start;
                endRange = CalendarView.SelectionRange.End.AddHours(23).AddMinutes(59).AddSeconds(59);
                SortApptByTime(startRange, endRange);
            }
            if (CustWApptsRdoButton.Checked)
            {
                FilterCustomersWithAppointments();
            }

        }

        //sorts appointmentview for appointments with selected customer.
        private void SortByCustomer(int custID)
        {
            filteredTable = dataSet.Tables["appointment"].Clone();
            foreach (DataRow row in dataSet.Tables["appointment"].Rows)
            {
                if (Convert.ToInt32(row["customerId"]) == custID)
                {
                    filteredTable.ImportRow(row);
                }
            }
            AppointmentView.DataSource = filteredTable;
        }

        //sorts appointmentview by time, day week or month.
        private void SortApptByTime(DateTime start, DateTime end)
        {
            DataTable filteredTable = dataSet.Tables["appointment"].Clone();
            foreach (DataRow row in dataSet.Tables["appointment"].Rows)
            {
                DateTime startLocal = Convert.ToDateTime(row["start"]);
                DateTime endLocal = Convert.ToDateTime(row["end"]);

                if (startLocal >= start && startLocal <= end)
                {
                    filteredTable.ImportRow(row);
                }
            }
            foreach (DataRow row in filteredTable.Rows)
            {
                Debug.WriteLine($"Filtered Row: ID= {row["appointmentId"]}, Start= {row["start"]}, End= {row["end"]}");
            }
            AppointmentView.DataSource = filteredTable;
        }

        //filters datagridview for customers by only having appointment holding customers in the current appointmentview selection
        private void FilterCustomersWithAppointments()
        {
            List<int> custIDs = new List<int>();
            DataTable currentFilteredTable = (DataTable)AppointmentView.DataSource;

            foreach (DataRow row in currentFilteredTable.Rows)
            {
                int custID = Convert.ToInt32(row["customerId"]);
                if (!custIDs.Contains(custID))
                {
                    custIDs.Add(custID);
                }
            }
            DataTable filteredCustTable = dataSet.Tables["customer"].Clone();
            foreach (int id in custIDs)
            {
                foreach (DataRow row in dataSet.Tables["customer"].Rows)
                {
                    if (Convert.ToInt32(row["customerId"]) == id)
                    {
                        filteredCustTable.ImportRow(row);
                    }
                }
            }
            CustomerView.DataSource = filteredCustTable;
            if (CustomerView.SelectedRows.Count > 0)
            {
                CustomerView.Rows[0].Selected = true;
            }
        }

        //checks for appointments starting in 15 minutes and displays a message box
        private void User15MinuteWarning()
        {
            foreach (DataRow row in dataSet.Tables["appointment"].Rows)
            {
                DateTime start = Convert.ToDateTime(row["start"]);
                DateTime now = DateTime.Now;
                TimeSpan diff = start - now;
                Debug.WriteLine($"start: {start}, now: {now}, diff: {diff}");
                if (diff.TotalMinutes <= 15 && diff.TotalMinutes >= 0 && currentUser.UserID == Convert.ToInt32(row["userId"]))
                {
                    int minutesToStart = Convert.ToInt32(diff.TotalMinutes);
                    MessageBox.Show($"Appointment ID: {row["appointmentId"]} is starting in {minutesToStart} minutes.");
                }
            }
        }

        //refreshes datagridview data
        public void RefreshData()
        {
            try
            {
                DataLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //constructs new default customer and passes into form
        private async void CustAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (DBConnection.connection.State != System.Data.ConnectionState.Open)
                {
                    await DBConnection.connection.OpenAsync();
                }

                string customerName = "";
                string createdBy = currentUser.UserName; 
                string lastUpdatedBy = createdBy;
                string countryName = "";
                string cityName = "";
                string addressLine1 = "";
                string addressLine2 = "";
                string postalCode = "";
                string phone = "";
                Address address = new Address(addressLine1, addressLine2, new City(cityName,
                    new Country(countryName, -1, DateTime.Now, currentUser.UserName, DateTime.Now, currentUser.UserName),
                    -1, DateTime.Now, currentUser.UserName, DateTime.Now, currentUser.UserName),
                    postalCode, phone, -1, DateTime.Now, currentUser.UserName, DateTime.Now, currentUser.UserName);

                Customer newCustomer = Customer.CreateNewCustomer(customerName, address, 1, createdBy, lastUpdatedBy);
                MainPage mainPage = this;
                CustomerForm customerForm = new CustomerForm(newCustomer, mainPage);
                customerForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //constructs customer from selectedCust, getting recursive address objects from subsequent IDs
        private async void CustModButton_Click(object sender, EventArgs e)
        {
            try
            {
                Customer modCustomer = null;
                if (selectedCustomer <= 0)
                {
                    MessageBox.Show("Select a customer to modify");
                    return;
                }
                else
                {
                    modCustomer = await Customer.GetCustomerAsync(selectedCustomer, currentUser);

                    if (modCustomer != null)
                    {
                        MainPage mainPage = this;
                        CustomerForm customerForm = new CustomerForm(modCustomer, mainPage);
                        customerForm.Show();
                        this.Hide();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        //Delete selected customer.  Checks in place to ensure customer does not have appointments
        private async void CustDelButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this customer?",
                "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string query = "DELETE FROM customer WHERE customerId = @CustomerId;";
                if (DBConnection.connection.State != ConnectionState.Open)
                {
                    await DBConnection.connection.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.connection))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", selectedCustomer);

                    try
                    {
                        if (DBConnection.connection.State != System.Data.ConnectionState.Open)
                        {
                            DBConnection.connection.Close();
                        }

                        await cmd.ExecuteNonQueryAsync();
                        MessageBox.Show("Customer deleted successfully.");

                        RefreshData();
                    }
                    catch (MySqlException ex) when (ex.Number == 1451 || ex.Number == 1452)
                    {
                        MessageBox.Show("Cannot delete customer with existing appointments");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                    finally
                    {
                        if (DBConnection.connection.State == System.Data.ConnectionState.Open)
                        {
                            DBConnection.connection.Close();
                        }
                    }

                }
            }

        }

        //add appointment by generating new default appt using selectedCust constructed cust and currentUser
        private async void ApptAddButton_Click(object sender, EventArgs e)
        {
            Customer customer = await Customer.GetCustomerAsync(selectedCustomer, currentUser);
            AppointmentForm appointmentForm = new AppointmentForm(this, Appointment.CreateNewAppointment(
               customer, currentUser));
            appointmentForm.Show();
            this.Hide();
        }

        //modify appointment by taking selected appt and cust, constructing appt from db using constructed
        //cust from selectedCust and currentUser, and passing into form
        private async void ApptModButton_Click(object sender, EventArgs e)
        {
            try
            {
                Appointment modAppointment = null;
                if (selectedAppointment <= 0)
                {
                    MessageBox.Show("Select an appointment to modify");
                    return;
                }
                else
                {
                    modAppointment = await Appointment.GetAppointmentAsync(selectedAppointment, currentUser, selectedCustomer); ;
                    if (modAppointment != null)
                    {
                        MainPage mainPage = this;
                        AppointmentForm appointmentForm = new AppointmentForm(mainPage, modAppointment);
                        appointmentForm.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        //Delete selected appointment
        private async void ApptDelButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this appointment?",
                "Confirm Delete", MessageBoxButtons.YesNo);
            if (DBConnection.connection.State != System.Data.ConnectionState.Open)
            {
                await DBConnection.connection.OpenAsync();
            }

            if (confirmResult == DialogResult.Yes)
            {
                string query = "DELETE FROM appointment WHERE appointmentId = @AppointmentId;";
                using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.connection))
                {
                    cmd.Parameters.AddWithValue("@AppointmentId", selectedAppointment);

                    try
                    {
                        if (DBConnection.connection.State != System.Data.ConnectionState.Open)
                        {
                            DBConnection.connection.Close();
                        }

                        await cmd.ExecuteNonQueryAsync();

                        MessageBox.Show("Appointment Deleted Successfully");

                        RefreshData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                    finally
                    {
                        if (DBConnection.connection.State == System.Data.ConnectionState.Open)
                        {
                            DBConnection.connection.Close();
                        }
                    }

                }
            }
        }

        //Filter appointments using calendarView
        private void CalendarView_DateSelected(object sender, DateRangeEventArgs e)
        {
            UpdateCalendarSelection();
            if (CustWApptsRdoButton.Checked)
            {
                FilterCustomersWithAppointments();
            }

        }

        //filter appointment view by day, week, month or customer.
        private void ApptView_CheckChanged(object sender, EventArgs e)
        {
            if (isHandlingCheckChanged)
            {
                return;
            }

            isHandlingCheckChanged = true;

            try
            {
                if (CustRdoButton.Checked)
                {
                    if (CustomerView.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Please select a customer.");
                        Task.Delay(100).ContinueWith(t =>
                        {
                            this.Invoke((Action)delegate
                            {
                                previousApptSelection.Checked = true;
                            });
                        });
                        return;
                    }

                    try
                    {
                        int selectedID = Convert.ToInt32(CustomerView.SelectedRows[0].Cells[0].Value);
                        SortByCustomer(selectedID);
                        UpdateAppointmentView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                        Task.Delay(100).ContinueWith(t =>
                        {
                            this.Invoke((Action)delegate
                            {
                                previousApptSelection.Checked = true;
                            });
                        });
                    }
                }
                else if (AllApptsRdoButton.Checked)
                {
                    AppointmentView.DataSource = null;
                    AppointmentView.DataSource = dataSet.Tables["appointment"];
                }
                else
                {
                    UpdateCalendarSelection();
                }
            }
            finally
            {
                isHandlingCheckChanged = false;
            }
        }

        //Filter Customers by Radio Button
        private void CustRdoButton_CheckChanged(object sender, EventArgs e)
        {
                    FilterCustomersWithAppointments();
        }

        //set int selectedAppointment for constructors
        private void AppointmentView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.AppointmentView.Rows[e.RowIndex];
                selectedAppointment = Convert.ToInt32(row.Cells["appointmentId"].Value);
            }

        }

        //set int selectedCustomer for constructors
        private void CustomerView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CustRdoButton.Checked)
            {
                UpdateAppointmentView();
            }
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.CustomerView.Rows[e.RowIndex];
                selectedCustomer = Convert.ToInt32(row.Cells["customerId"].Value);
            }
        }

        //exit application
        private void LogoffButton_Click(object sender, EventArgs e)
        {
            DBConnection.stopConnection();
            Application.Exit();
        }

        //Display all customers
        private void AllCustRdoButton_CheckedChanged(object sender, EventArgs e)
        {
            CustomerView.DataSource = null;
            CustomerView.DataSource = dataSet.Tables["customer"];
            try
            {
                Debug.WriteLine("Resetting Customer View");
                Debug.WriteLine($"Total Customers: {dataSet.Tables["customer"].Rows.Count}");
                if (CustomerView.SelectedRows.Count > 0)
                {
                    CustomerView.Rows[0].Selected = true;
                }
                Debug.WriteLine("Customer view reset complete");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error resetting customer view:  {ex.Message}");
            }
        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm(this);
            reportsForm.Show();
            this.Hide();
        }
    }
}
