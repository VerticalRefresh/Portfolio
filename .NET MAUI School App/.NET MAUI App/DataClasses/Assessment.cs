using SQLite;
using System.ComponentModel;

namespace Barham_C971.DataClasses
{
    public class Assessment : INotifyPropertyChanged
    {
        //Assessments are assigned to a course and are unique to each course

        //Assessments belong to course on a 1 to many basis
        [PrimaryKey, AutoIncrement]
        public int AssessmentID { get; set; }

        //Foreign key to declare the course that the assessment is assigned to
        public int CourseID { get; set; }

        //Assessment Name
        private string assessmentName;
        public string AssessmentName
        {
            get => assessmentName;
            set
            {
                if (assessmentName != value)
                {
                    assessmentName = value;
                    OnPropertyChanged();
                }
            }
        }

        //Assessment Status
        private string assessmentStatus;
        public string AssessmentStatus
        {
            get => assessmentStatus;
            set
            {
                if (assessmentStatus != value)
                {
                    assessmentStatus = value;
                    OnPropertyChanged();
                }
            }
        }

        //Assessment Type
        private string assessmentType;
        public string AssessmentType
        {
            get => assessmentType;
            set
            {
                if (assessmentType != value)
                {
                    assessmentType = value;
                    OnPropertyChanged();
                }
            }
        }

        //Assessment Start Date
        private DateTime assessmentStartDate;
        public DateTime AssessmentStartDate
        {
            get => assessmentStartDate;
            set
            {
                if (assessmentStartDate != value)
                {
                    assessmentStartDate = value;
                    OnPropertyChanged();
                }
            }
        }

        //Assessment End Date
        private DateTime assessmentEndDate;
        public DateTime AssessmentEndDate
        {
            get => assessmentEndDate;
            set
            {
                if (assessmentEndDate != value)
                {
                    assessmentEndDate = value;
                    OnPropertyChanged();
                }
            }
        }

        //Assessment Details
        private string assessmentNotes;
        public string AssessmentNotes
        {
            get => assessmentNotes;
            set
            {
                if (assessmentNotes != value)
                {
                    assessmentNotes = value;
                    OnPropertyChanged();
                }
            }
        }

        //Property Changed handler for UI
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
