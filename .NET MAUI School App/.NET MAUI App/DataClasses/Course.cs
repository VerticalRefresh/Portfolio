using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Barham_C971.DataClasses
{
    public class Course : INotifyPropertyChanged
    {
        //Courses are assigned to each term on a many to one basis

        [PrimaryKey, AutoIncrement]
        public int CourseID { get; set; }
        
        //Foreign key to declare the instructor assigned to the course

        private int instructorID;
        public int InstructorID
        {
            get => instructorID;
            set
            {
                if (instructorID != value)
                {
                    instructorID = value;
                    OnPropertyChanged();
                }
            }
        }
        //Foreign key to declare the term that the course is assigned to
        public int TermID { get; set; }

        private string courseName;
        public string CourseName
        {
            get => courseName;
            set
            {
                if (courseName != value)
                {
                    courseName = value;
                    OnPropertyChanged();
                }
            }
        }

        //Course Status
        public string courseStatus;
        public string CourseStatus
        {
            get => courseStatus;
            set
            {
                if (courseStatus != value)
                {
                    courseStatus = value;
                    OnPropertyChanged();
                }
            }
        }

        //Course Notes
        public string courseNotes;
        public string CourseNotes
        {
            get => courseNotes;
            set
            {
                if (courseNotes != value)
                {
                    courseNotes = value;
                    OnPropertyChanged();
                }
            }
        }

        //Course Start Date
        private DateTime courseStartDate;
        public DateTime CourseStartDate
        {
            get => courseStartDate;
            set
            {
                if (courseStartDate != value)
                {
                    courseStartDate = value;
                    OnPropertyChanged();
                }
            }
        }

        //Course End Date
        private DateTime courseEndDate;
        public DateTime CourseEndDate
        {
            get => courseEndDate;
            set
            {
                if (courseEndDate != value)
                {
                    courseEndDate = value;
                    OnPropertyChanged();
                }
            }
        }

        //Course Details
        private string courseDetails;
        public string CourseDetails
        {
            get => courseDetails;
            set
            {
                if (courseDetails != value)
                {
                    courseDetails = value;
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
