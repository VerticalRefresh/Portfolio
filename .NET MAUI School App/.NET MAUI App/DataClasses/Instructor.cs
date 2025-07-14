using System.ComponentModel;
using SQLite;
using System.Runtime.CompilerServices;

namespace Barham_C971.DataClasses
{
    //Instructors are associated with courses on a 1 to 1 basis
    public class Instructor : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int InstructorID { get; set; }

        //Instructor Name
        private string instructorName;
        public string InstructorName 
        {
            get => instructorName;
            set
            {
                if (instructorName != value)
                {
                    instructorName = value;
                    OnPropertyChanged();
                }
            }
        }

        //Phone Number
        private string instructorPhone;
        public string InstructorPhone
        {
            get => instructorPhone;
            set
            {
                if (instructorPhone != value)
                {
                    instructorPhone = value;
                    OnPropertyChanged();
                }
            }
        }

        //Email Address
        private string instructorEmail;
        public string InstructorEmail
        {
            get => instructorEmail;
            set
            {
                if (instructorEmail != value)
                {
                    instructorEmail = value;
                    OnPropertyChanged();
                }
            }
        }

        //Property Changed Handler for UI Updates
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
