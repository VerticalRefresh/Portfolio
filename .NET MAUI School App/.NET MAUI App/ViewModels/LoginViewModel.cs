using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Barham_C971.DataClasses;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace Barham_C971.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        string username;
        public string Username
        {
            get => username;
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged();
                }
            }
        }

        string password;
        public string Password
        {
            get => password;
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginAsync());
        }

        private async Task LoginAsync()
        {
            var student = await App.Database.Table<Student>().Where(s => s.StudentName == Username && s.StudentPassword == Password).FirstOrDefaultAsync();

            if (student == null)
            {
                await Application.Current.MainPage.DisplayAlert("Login Failed", "Invalid username or password.", "OK");
            }
            else
            {
                Debug.WriteLine($"Student ID {student.StudentID} passing to MainPage");
                // Navigate to the main page
                await Shell.Current.GoToAsync($"//MainPage?studentId={student.StudentID}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
