using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Barham_C971.DataClasses
{
    //Terms are assigned to each student and are unique to each student
    public class Term : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int TermID { get; set; }

        //Foreign key to declare the student that the term is assigned to, governs all other foreign keys to keep data unique per student
        public int StudentID { get; set; }

        //Term Name
        private string termName;
        public string TermName
        {
            get => termName;
            set
            {
                if (termName != value)
                {
                    termName = value;
                    OnPropertyChanged();
                }
            }
        }

        //Term Status, calculated based on the current date and the term start and end dates
        public string TermStatus
        {
            get
            {
                var now = DateTime.Now;
                if (now < TermStartDate)
                {
                    return "Upcoming";
                }
                else if (now > TermEndDate)
                {
                    return "Completed";
                }
                else
                {
                    return "In Progress";
                }
            }
        }

        //Term Start Date
        private DateTime termStartDate;
        public DateTime TermStartDate
        {
            get => termStartDate;
            set
            {
                if (termStartDate != value)
                {
                    termStartDate = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TermStatus)); // Update TermStatus when TermStartDate changes
                }
            }
        }

        //Term End Date
        private DateTime termEndDate;
        public DateTime TermEndDate
        {
            get => termEndDate;
            set
            {
                if (termEndDate != value)
                {
                    termEndDate = value;
                    OnPropertyChanged();
                }
            }
        }

        //Term Course List
        [Ignore]
        public ObservableCollection<Course> Courses { get; set; } = new ObservableCollection<Course>();

        //Is term currently selected
        private bool isSelected;

        [Ignore]
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if(isSelected != value)
                {
                    isSelected = value;
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
