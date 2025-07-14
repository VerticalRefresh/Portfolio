using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Barham_WGUD969_Assessment.Classes;
using MySql.Data.MySqlClient;

namespace Barham_WGUD969_Assessment.Windows
{
    public partial class ReportsForm : Form
    {
        private MainPage mainPage;
        private DateTime date = DateTime.Now;
        private DataSet dataSet;

        //Constructor
        public ReportsForm(MainPage mainPage)
        {
            dataSet = new DataSet();
            this.mainPage = mainPage;
            InitializeComponent();
            ApptByMonthPicker.Format = DateTimePickerFormat.Custom;
            ApptByMonthPicker.CustomFormat = "MMMM yyyy";
            ApptByMonthPicker.ShowUpDown = true;
            string custQuery = "SELECT * FROM customer";
            string userQuery = "SELECT * FROM user";
            string apptQuery = "SELECT * FROM appointment";
            using (MySqlDataAdapter userAdapter = new MySqlDataAdapter(userQuery, DBConnection.connection))
            {
                userAdapter.Fill(dataSet, "user");
            }
            using (MySqlDataAdapter custAdapter = new MySqlDataAdapter(custQuery, DBConnection.connection))
            {
                custAdapter.Fill(dataSet, "customer");
            }
            using (MySqlDataAdapter apptAdapter = new MySqlDataAdapter(apptQuery, DBConnection.connection))
            {
                apptAdapter.Fill(dataSet, "appointment");
            }

        }

        //Exit Program
        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            mainPage.Show();
            this.Close();
        }
        //Load data based on selected date
        private void ApptByMonthPicker_ValueChanged(object sender, EventArgs e)
        {
            FetchAndDisplayData();
        }
        //Load users into combobox
        private void LoadUsersIntoComboBox()
        {
            UserCustComboBox.Items.Clear();
            UserCustComboBox.Text = "";
            DataTable dataTable = dataSet.Tables["user"];
            foreach (DataRow row in dataTable.Rows)
            {
                UserCustComboBox.Items.Add(new ComboBoxItem(row["userName"].ToString(), row["userId"].ToString()));
            }
        }
        //Load customers into combobox
        private void LoadCustomersIntoComboBox()
        {
            UserCustComboBox.Items.Clear();
            UserCustComboBox.Text = "";
            DataTable dataTable = dataSet.Tables["customer"];
            foreach (DataRow row in dataTable.Rows)
            {
                UserCustComboBox.Items.Add(new ComboBoxItem(row["customerName"].ToString(), row["customerId"].ToString()));
            }
        }
        //Fetch and display data based on selected radio button
        private void FetchAndDisplayData()
        {
            if (ApptsByMonthRdoButton.Checked)
            {
                DateTime selectedDate = ApptByMonthPicker.Value;
                Debug.WriteLine(selectedDate);
                DisplayAppointmentsByMonth(selectedDate);
            }
            else if (SchedByUserRdoButton.Checked)
            {
                if (UserCustComboBox.SelectedItem is ComboBoxItem selectedItem)
                {
                    string userId = selectedItem.Value;
                    DisplayScheduleByUser(Convert.ToInt32(userId));
                }
            }
            else if (ScheduleByCustRdoButton.Checked)
            {
                if (UserCustComboBox.SelectedItem is ComboBoxItem selectedItem)
                {
                    string customerId = selectedItem.Value;
                    DisplayScheduleByCustomer(Convert.ToInt32(selectedItem.Value));
                }
            }
        }
        //Display appointments by month
        private void DisplayAppointmentsByMonth(DateTime date)
        {
            DataTable filteredTable = new DataTable();
            filteredTable.Columns.Add("Type", typeof(string));
            filteredTable.Columns.Add("Count", typeof(int));

            //Lambda filters rows type and count making foreach expression more readable

            var groupedRows = dataSet.Tables["appointment"].AsEnumerable().Where(row =>
            ((DateTime)row["start"]).ToLocalTime().Month == date.Month && 
            ((DateTime)row["start"]).ToLocalTime().Year == date.Year)
                .GroupBy(row => row["type"].ToString())
                .Select(g => new { Type = g.Key, Count = g.Count() });
            

            foreach (var row in groupedRows)
            {
                DataRow newRow = filteredTable.NewRow();
                newRow["Type"] = row.Type;
                newRow["Count"] = row.Count;
                filteredTable.Rows.Add(newRow);
            }

            ReportView.DataSource = filteredTable;

            foreach (DataGridViewColumn column in ReportView.Columns)
            {
                column.Visible = new[] { "Type", "Count" }.Contains(column.Name);
            }
        }
        //Display schedule by user
        private void DisplayScheduleByUser(int searchId)        
        {
            DataTable userTable = dataSet.Tables["user"];
            DataTable filteredTable = dataSet.Tables["appointment"].Clone();
            DataRow[] userRows = userTable.Select($"userId = '{searchId}'");
            if (userRows.Length == 0)
            {
                MessageBox.Show("User not found");
                return;
            }

            //Lambda filters rows by userId, making foreach expression more readable
            var filteredRows = dataSet.Tables["appointment"].AsEnumerable().Where(row => 
                Convert.ToInt32(row["userId"]) == searchId)
                .OrderBy(row => (DateTime)row["start"]);
            
            foreach (var row in filteredRows)
            {
                if (Convert.ToInt32(row["userId"]) == searchId)
                {
                    DataRow newRow = filteredTable.NewRow();
                    newRow["customerId"] = row["customerId"];
                    newRow["userId"] = row["userId"];
                    newRow["type"] = row["type"];
                    newRow["start"] = ((DateTime)row["start"]).ToLocalTime().ToString("g");
                    newRow["end"] = ((DateTime)row["end"]).ToLocalTime().ToString("g");
                    filteredTable.Rows.Add(newRow);
                }
            }
            ReportView.DataSource = filteredTable;

            foreach (DataGridViewColumn column in ReportView.Columns)
            {
                column.Visible = new[] { "customerId", "userId", "type", "start", "end" }.Contains(column.Name);
            }
        }
        //Display schedule by customer
        private void DisplayScheduleByCustomer(int searchId)
        {
            DataTable customerTable = dataSet.Tables["customer"];
            DataTable filteredTable = dataSet.Tables["appointment"].Clone();
            DataRow[] customerRows = customerTable.Select($"customerId = '{searchId}'");
            if (customerRows.Length == 0)
            {
                MessageBox.Show("Customer not found");
                return;
            }

            var filteredRows = dataSet.Tables["appointment"].AsEnumerable().Where(row =>
                Convert.ToInt32(row["customerId"]) == searchId)
                .OrderBy(row => (DateTime)row["start"]);

            //Lambda filters rows by customerId, making foreach expression more readable
            foreach (var row in filteredRows)
            {
                if (Convert.ToInt32(row["customerId"]) == searchId)
                {
                    DataRow newRow = filteredTable.NewRow();
                    newRow["customerId"] = row["customerId"];
                    newRow["userId"] = row["userId"];
                    newRow["type"] = row["type"];
                    newRow["start"] = ((DateTime)row["start"]).ToLocalTime().ToString("g");
                    newRow["end"] = ((DateTime)row["end"]).ToLocalTime().ToString("g");
                    filteredTable.Rows.Add(newRow);
                }
            }
            ReportView.DataSource = filteredTable;

            foreach (DataGridViewColumn column in ReportView.Columns)
            {
                column.Visible = new[] { "customerId", "userId", "type", "start", "end" }.Contains(column.Name);
            }
        }
        //ComboBoxItem class for combobox items, includes name and ID
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public ComboBoxItem(string text, string value)
            {
                Text = text;
                Value = value;
            }
            public override string ToString()
            {
                return Text;
            }
        }
        //Display data based on selected combo box item
        private void UserCustComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FetchAndDisplayData();
        }
        //Radio button event handlers
        private void ApptsByMonthRdoButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ApptsByMonthRdoButton.Checked)
            {
                ApptByMonthPicker.Show();
                UserCustComboBox.Hide();
                ReportView.DataSource = null;
            }
        }

        private void SchedByUserRdoButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SchedByUserRdoButton.Checked)
            {
                UserCustComboBox.Show();
                ApptByMonthPicker.Hide();
                LoadUsersIntoComboBox();
                ReportView.DataSource = null;
            }
        }

        private void ScheduleByCustRdoButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ScheduleByCustRdoButton.Checked)
            {
                UserCustComboBox.Show();
                ApptByMonthPicker.Hide();
                LoadCustomersIntoComboBox();
                ReportView.DataSource = null;
            }
        }
        //Formatting for data grid view
        private void ReportView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ReportView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ReportView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (ReportView.Columns.Contains("appointmentId"))
            {
                ReportView.Columns["appointmentId"].HeaderText = "Appt. ID";
            }
            if (ReportView.Columns.Contains("customerId"))
            {
                ReportView.Columns["customerId"].HeaderText = "Customer ID";
            }
            if (ReportView.Columns.Contains("userId"))
            {
                ReportView.Columns["userId"].HeaderText = "User ID";
            }
            if (ReportView.Columns.Contains("type"))
            {
                ReportView.Columns["type"].HeaderText = "Type";
            }
            if (ReportView.Columns.Contains("start"))
            {
                ReportView.Columns["start"].HeaderText = "Start";
            }
            if (ReportView.Columns.Contains("end"))
            {
                ReportView.Columns["end"].HeaderText = "End";
            }

        }
    }
}

