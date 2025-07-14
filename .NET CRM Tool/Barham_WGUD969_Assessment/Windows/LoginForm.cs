using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Barham_WGUD969_Assessment.Classes;
using Barham_WGUD969_Assessment.Windows;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

namespace Barham_WGUD969_Assessment
{
    public partial class LoginForm : Form
    {
        private string errorString = "Please enter a valid username and password.";
        private static string logFilePath = @"..\..\LogFile\Login_History.txt";

        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = LoginButton;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {

            string username = UserNameBox.Text;
            string password = PasswordBox.Text;
            string query = "SELECT * FROM user WHERE username = @username AND password = @password";

            if (DBConnection.connection == null || DBConnection.connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Database Connection Not Open");
                return;
            }
            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.connection))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            User user = new User(
                                reader.GetInt32("userId"),
                                reader.GetString("userName"),
                                reader.GetString("password"),
                                reader.GetInt32("active"),
                                reader.GetDateTime("createDate"),
                                reader.GetString("createdBy"),
                                reader.GetDateTime("lastUpdate"),
                                reader.GetString("lastUpdateBy")
                            );
                            reader.Close();
                            MainPage mainPage = new MainPage(user);
                            mainPage.Show();
                            this.Hide();
                            LogMessage($"Successful Login: {user.UserName}");
                        }
                        else
                        {
                            MessageBox.Show(errorString);
                            LogMessage($"Failed Login: {username}");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        //Data validations
        private void UserNameBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserNameBox.Text))
            {
                UserNameBox.BackColor = Color.Red;
            }
            else
            {
                UserNameBox.BackColor = Color.White;
            }
            LoginCheck();
        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordBox.Text))
            {
                PasswordBox.BackColor = Color.Red;
            }
            else
            {
                PasswordBox.BackColor = Color.White;
            }
            LoginCheck();
        }

        private void LoginCheck()
        {
            if (string.IsNullOrWhiteSpace(UserNameBox.Text) || string.IsNullOrWhiteSpace(PasswordBox.Text))
            {
                LoginButton.Enabled = false;
            }
            else
            {
                LoginButton.Enabled = true;
            }
        }

        //Login record logging
        private void LogMessage(string message)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{message} {DateTime.Now}");
            }
        }

        //Load functions
        private async void LoginForm_Load(object sender, EventArgs e)
        {
            //LoginButton.Enabled = false;
            await LoginTranslate();
            DBConnection.startConnection();
        }

        //Translation service, pick your language!

        private async Task LoginTranslate()
        {
            string userCulture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            string apiKey = "AIzaSyBSjhibbpXBKVDAkocDsyiQ_j_wtE_upsw";
            string labeltext = FormLabel.Text;
            string untext = UserNameLabel.Text;
            string pwtext = PasswordLabel.Text;
            string logintext = LoginButton.Text;
            string errorText = errorString;
            string url = $"https://translation.googleapis.com/language/translate/v2?key={apiKey}";
            if (userCulture != "en")
            {
                var requestBody = new { q = labeltext, target = userCulture, source = "en" };
                var requestBody2 = new { q = untext, target = userCulture, source = "en" };
                var requestBody3 = new { q = pwtext, target = userCulture, source = "en" };
                var requestBody4 = new { q = logintext, target = userCulture, source = "en" };
                var requestBody5 = new { q = errorText, target = userCulture, source = "en" };

                string jsonRequestBody = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
                string jsonRequestBody2 = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody2);
                string jsonRequestBody3 = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody3);
                string jsonRequestBody4 = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody4);
                string jsonRequestBody5 = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody5);

                using (HttpClient client = new HttpClient())
                {
                    FormLabel.Text = await TranslateText(client, url, jsonRequestBody);
                    UserNameLabel.Text = await TranslateText(client, url, jsonRequestBody2);
                    PasswordLabel.Text = await TranslateText(client, url, jsonRequestBody3);
                    LoginButton.Text = await TranslateText(client, url, jsonRequestBody4);
                    errorString = await TranslateText(client, url, jsonRequestBody5);
                }
            }
        }

        private async Task<string> TranslateText(HttpClient client, string url, string jsonRequestBody)
        {
            try
            {
                using (HttpResponseMessage response = await client.PostAsync(url, new StringContent(jsonRequestBody, Encoding.UTF8, "application/json")))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        JObject json = JObject.Parse(data);

                        if (json["data"] != null && json["data"]["translations"] != null && json["data"]["translations"].Count() > 0)
                        {
                            string translatedText = json["data"]["translations"][0]["translatedText"].ToString();
                            return translatedText;
                        }
                        else
                        {
                            MessageBox.Show("Translation failed: Unexpected response format.");
                        }
                    }
                    else
                    {
                        string errorResponse = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Translation failed: " + errorResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            return null;
        }
    }
}
