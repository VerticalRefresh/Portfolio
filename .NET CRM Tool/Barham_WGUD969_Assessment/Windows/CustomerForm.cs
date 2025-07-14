using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Barham_WGUD969_Assessment.Classes;
using MySql.Data.MySqlClient;

namespace Barham_WGUD969_Assessment.Windows
{
    public partial class CustomerForm : Form
    {
        Customer formCustomer; //customer object to hold customer data
        int active = 1;
        MainPage mainPage; //main page object to return to after cancel or save
        public CustomerForm(Customer customer, MainPage mainPage)
        {
            InitializeComponent();
            formCustomer = customer;
            this.mainPage = mainPage;
            ValidateFields();
        }

        //create customer object and save to database as new or update existing
        private async void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                TrimFields();

                if (DBConnection.connection.State != System.Data.ConnectionState.Open)
                {
                    await DBConnection.connection.OpenAsync();
                }

                string countryName = CustCountryBox.Text;
                string cityName = CustCityBox.Text;
                string addressLine1 = CustAddrBox.Text;
                string addressLine2 = CustAddr2Box.Text;
                string postalCode = CustPostCodeBox.Text;
                string phone = CustPhoneBox.Text;
                string createdBy = CreatedByBox.Text;
                int customerID;

                Country country = await Country.GetOrAddCountryAsync(DBConnection.connection, countryName, createdBy);

                City city = await City.GetOrAddCityAsync(DBConnection.connection, cityName, country, createdBy);

                Address address = await Address.GetOrAddAddressAsync(DBConnection.connection, addressLine1, addressLine2, city, postalCode, phone, createdBy);
                if (CustIDBox.Text == "New Customer")
                {
                    customerID = -1;
                }
                else
                {
                    customerID = int.Parse(CustIDBox.Text);
                }

                Customer customer = new Customer(
                    customerID, CustNameBox.Text, address, active, createDate: DateTime.Now, createdBy: createdBy,
                    lastUpdate: DateTime.Now, lastUpdatedBy: createdBy);

                await InsertOrUpdateCustomerAsync(DBConnection.connection, customer);

                MessageBox.Show("Customer saved successfully.");
            }
            catch (Exception ex)
            {
                StringBuilder errorMessage = new StringBuilder();
                errorMessage.AppendLine("Error saving customer:");
                errorMessage.AppendLine($"Customer ID: {CustIDBox.Text}");
                errorMessage.AppendLine($"Customer Name: {CustNameBox.Text}");
                errorMessage.AppendLine($"Address Line 1: {CustAddrBox.Text}");
                errorMessage.AppendLine($"Address Line 2: {CustAddr2Box.Text}");
                errorMessage.AppendLine($"City Name: {CustCityBox.Text}");
                errorMessage.AppendLine($"Country Name: {CustCountryBox.Text}");
                errorMessage.AppendLine($"Postal Code: {CustPostCodeBox.Text}");
                errorMessage.AppendLine($"Phone: {CustPhoneBox.Text}");
                errorMessage.AppendLine($"Created By: {CreatedByBox.Text}");
                errorMessage.AppendLine($"Error Message: {ex.Message}");
                MessageBox.Show(errorMessage.ToString());

            }
            finally
            {
                if (DBConnection.connection.State == System.Data.ConnectionState.Open)
                {
                    await DBConnection.connection.CloseAsync();
                }
                mainPage.RefreshData();
                mainPage.Show();
                this.Close();
            }
        }
        //Insert or update customer in database
        private async Task InsertOrUpdateCustomerAsync(MySqlConnection connection, Customer customer)
        {
            string insertQuery = @"
                INSERT INTO customer (customerName, addressID, active, createDate, createdBy, lastUpdate, lastUpdateBy)
                VALUES (@CustomerName, @AddressID, @Active, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdatedBy)";
            string updateQuery = @"
                UPDATE customer
                SET customerName = @CustomerName, addressID = @AddressID, active = @Active, lastUpdate = @LastUpdate, lastUpdateBy = @LastUpdatedBy
                WHERE customerID = @CustomerID";
            if (connection.State != System.Data.ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            using (MySqlCommand cmd = new MySqlCommand(customer.CustomerID == -1 ? insertQuery : updateQuery, DBConnection.connection))
            {
                cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                cmd.Parameters.AddWithValue("@AddressID", customer.Address.AddressID);
                cmd.Parameters.AddWithValue("@Active", customer.Active);
                cmd.Parameters.AddWithValue("@CreateDate", customer.CreateDate.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@CreatedBy", customer.CreatedBy);
                cmd.Parameters.AddWithValue("@LastUpdate", customer.LastUpdate.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@LastUpdatedBy", customer.LastUpdatedBy);

                try
                {
                    await cmd.ExecuteNonQueryAsync();

                    if (customer.CustomerID == -1)
                    {
                        customer.CustomerID = (int)cmd.LastInsertedId;
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

        //Load form and populate textboxes with customer data
        private void CustomerForm_Load(object sender, EventArgs e)
        {

            if (formCustomer.CustomerID == -1)
            {
                CustIDBox.Text = "New Customer";
            }
            else
            {
                CustIDBox.Text = formCustomer.CustomerID.ToString();
            }
            CustNameBox.Text = formCustomer.CustomerName;
            CustAddrBox.Text = formCustomer.Address.AddressLine1.ToString();
            CustAddr2Box.Text = formCustomer.Address.AddressLine2.ToString();
            CustCityBox.Text = formCustomer.Address.City.CityName.ToString();
            CustCountryBox.Text = formCustomer.Address.City.Country.CountryName.ToString();
            CustPhoneBox.Text = formCustomer.Address.Phone.ToString();
            CustPostCodeBox.Text = formCustomer.Address.PostalCode.ToString();
            ActiveCheckBox.Checked = formCustomer.Active == 1;
            CreatedDateBox.Text = formCustomer.CreateDate.ToLocalTime().ToString();
            CreatedByBox.Text = formCustomer.CreatedBy;
            ModDateBox.Text = formCustomer.LastUpdate.ToLocalTime().ToString();
            ModByBox.Text = formCustomer.LastUpdatedBy;

            ValidateFields();
        }
        //Textbox validations
        private void ValidateFields()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(CustNameBox.Text))
            {
                CustNameBox.BackColor = Color.Red;
                isValid = false;
            }
            else
            {
                CustNameBox.BackColor = Color.White;
            }

            if (string.IsNullOrWhiteSpace(CustAddrBox.Text))
            {
                CustAddrBox.BackColor = Color.Red;
                isValid = false;
            }
            else
            {
                CustAddrBox.BackColor = Color.White;
            }

            if (string.IsNullOrWhiteSpace(CustCityBox.Text))
            {
                CustCityBox.BackColor = Color.Red;
                isValid = false;
            }
            else
            {
                CustCityBox.BackColor = Color.White;
            }

            if (string.IsNullOrWhiteSpace(CustCountryBox.Text))
            {
                CustCountryBox.BackColor = Color.Red;
                isValid = false;
            }
            else
            {
                CustCountryBox.BackColor = Color.White;
            }

            if (!Regex.IsMatch(CustPostCodeBox.Text, @"^\d{5}$"))
            {
                CustPostCodeBox.BackColor = Color.Red;
                isValid = false;
            }
            else
            {
                CustPostCodeBox.BackColor = Color.White;
            }

            if (!Regex.IsMatch(CustPhoneBox.Text, @"^(\(\d{3}\)\s?|\d{3}[-.\s]?)\d{3}[-.\s]?\d{4}$"))
            {
                CustPhoneBox.BackColor = Color.Red;
                isValid = false;
            }
            else
            {
                CustPhoneBox.BackColor = Color.White;

            }
            WarningLabel.Visible = !isValid;
            SaveButton.Enabled = isValid;
        }
        //set Active variable to 0 or 1
        private void ActiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ActiveCheckBox.Checked)
            {
                active = 1;
            }
            else
            {
                active = 0;
            }
        }
        //Cancel without saving customer
        private void CancelButton_Click(object sender, EventArgs e)
        {
            mainPage.Show();
            this.Close();
        }

        //Grouped texbox validation on text change
        private void EditBox_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        //Trim whitespace from textboxes
        private void TrimFields()
        {
            CustNameBox.Text = CustNameBox.Text.Trim();
            CustAddrBox.Text = CustAddrBox.Text.Trim();
            CustAddr2Box.Text = CustAddr2Box.Text.Trim();
            CustCityBox.Text = CustCityBox.Text.Trim();
            CustCountryBox.Text = CustCountryBox.Text.Trim();
            CustPostCodeBox.Text = CustPostCodeBox.Text.Trim();
            CustPhoneBox.Text = CustPhoneBox.Text.Trim();
        }
    }
}
