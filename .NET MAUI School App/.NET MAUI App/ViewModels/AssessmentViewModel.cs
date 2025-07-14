


using Barham_C971.DataClasses;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Barham_C971.ViewModels
{

    //View model controls data binding and logic for the Assessment page
    public class AssessmentViewModel : INotifyPropertyChanged
    {
        //Boolean to determine if the user is editing the assessment and modify UI
        private bool isEditingAssessment;
        public bool IsEditingAssessment
        {
            get => isEditingAssessment;
            set
            {
                if (isEditingAssessment != value)
                {
                    isEditingAssessment = value;
                    OnPropertyChanged();
                }
            }
        }

        //Assessment to bind to the view
        private Assessment assessment;
        public Assessment Assessment
        {
            get => assessment;
            set
            {
                if (assessment != value)
                {
                    assessment = value;
                    OnPropertyChanged();
                }
            }
        }

        //Instructor from course, not editable in this page
        private Instructor instructor;
        public Instructor Instructor
        {
            get => instructor;
            set
            {
                if (instructor != value)
                {
                    instructor = value;
                    OnPropertyChanged();
                }
            }
        }

        //Course from course, not editable in this page
        private Course course;
        public Course Course
        {
            get => course;
            set
            {
                if (course != value)
                {
                    course = value;
                    OnPropertyChanged();
                }
            }
        }

        //List of assessments to create collectionview at the end of page
        private ObservableCollection<Assessment> assessments = new ();
        
        public ObservableCollection<Assessment> Assessments
        {
            get => assessments;
            set
            {
                if (assessments != value)
                {
                    assessments = value;
                    OnPropertyChanged();
                }
            }
        }

        //Assessment Status Options
        public IReadOnlyList<String> StatusOptions { get; } = new[]
        {
            "Not Started",
            "In Progress",
            "Passed",
            "Needs Resubmission"
        };

        //Assessment Type Options
        public IReadOnlyList<String> TypeOptions { get; } = new[]
        {
            "Objective",
            "Performance"
        };

        //Constructor to initialize the commands
        public AssessmentViewModel()
        {
            SaveAssessmentCommand = new Command(SaveAssessment);
            CancelAssessmentCommand = new Command(Cancel);
            EditAssessmentCommand = new Command(EditAssessment);
            DeleteAssessmentCommand = new Command(DeleteAssessment);
            BackCommand = new Command(Back);
            OnEmailLabelTappedCommand = new Command(OnEmailLabelTapped);
            OnPhoneTappedCommand = new Command(OnPhoneTapped);
            HomeCommand = new Command(Home);
            ToggleNotificationsCommand = new Command(async () => await AskAndScheduleNotifications());

        }

        //Commands to bind to the buttons in the view
        public ICommand SaveAssessmentCommand { get; }
        public ICommand CancelAssessmentCommand { get; }
        public ICommand EditAssessmentCommand { get; }
        public ICommand DeleteAssessmentCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand OnEmailLabelTappedCommand { get; }
        public ICommand OnPhoneTappedCommand { get; }
        public ICommand HomeCommand { get; }
        public ICommand ToggleNotificationsCommand { get; }

        //Load the assessment data
        public async Task LoadAssessmentDataAsync(int assessmentId)
        {
            var assessment = await App.Database.GetAssessmentAsync(assessmentId);
            var course = await App.Database.GetCourseAsync(assessment.CourseID);
            var instructor = await App.Database.GetInstructorAsync(course.InstructorID);
            var assessments = await App.Database.GetAssessmentsByCourseIdAsync(course.CourseID);
            if (assessment != null)
            {
                Assessment = assessment;
            }
            if (course != null)
            {
                Course = course;
            }
            if (instructor != null)
            {
                Instructor = instructor;
            }
            if (assessments != null)
            {
                foreach (var item in assessments)
                {
                    Assessments.Add(item);
                }
            }
            //****I want to remove the currently bound assessment from the list at the bottom of the page
            Assessments.Remove(Assessment);
        }

        //Command methods for taps

        //Command method to go to the home page
        private async void Home()
        {
            if (IsEditingAssessment)
            {
                IsEditingAssessment = false;
            }
            Debug.WriteLine("Proceed to Home Page");
            await Shell.Current.Navigation.PopToRootAsync();
            Debug.WriteLine("Proceed to Home Page");
        }
        
        //Command method to delete the assessment
        private async void DeleteAssessment()
        {
            bool ok = await Application.Current.MainPage.DisplayAlert(
                "Delete Term",
                $"Are you sure you want to delete the Assessment '{Assessment.AssessmentName}'",
                "Yes",
                "No");
            if (!ok) return;

            await App.Database.DeleteAssessmentAsync(Assessment);
            IsEditingAssessment = false;
            Assessments.Remove(Assessment);
            Assessments.Clear();
            var list = await App.Database.GetAssessmentsByCourseIdAsync(Course.CourseID);
            foreach (var item in list)
            {
                Assessments.Add(item);
            }
            await Shell.Current.GoToAsync("..");
        }

        //Command method to save the assessment
        private async void SaveAssessment()
        {
            await SaveAssessmentAsync();
            OnPropertyChanged();
            Assessments.Clear();
            var list = await App.Database.GetAssessmentsByCourseIdAsync(Assessment.CourseID);
            foreach (var item in list)
            {
                Assessments.Add(item);
            }
        }

        //Command method to cancel the edit
        private async void Cancel()
        {
            if (Assessment.AssessmentID == 0)
            {
                await App.Database.DeleteAssessmentAsync(Assessment);
                await Shell.Current.GoToAsync("//CoursePage");
            }
            IsEditingAssessment = false;
            if (Assessments != null)
            {
                Assessment = Assessments.FirstOrDefault(a => a.AssessmentID == Assessment.AssessmentID);
            }
        }

        //Command method to edit the assessment
        private void EditAssessment()
        {
            IsEditingAssessment = true;
        }

        //Command method to open phone app when instructor phone tapped
        private void OnPhoneTapped()
        {
            var phoneNumber = Instructor.InstructorPhone;
            var uri = new Uri($"tel:{phoneNumber}");
            Launcher.OpenAsync(uri);
        }

        //Command method to open email app when instructor email tapped
        private void OnEmailLabelTapped()
        {
            var email = Instructor.InstructorEmail;
            var subject = "Inquiry about " + Assessment.AssessmentName;
            var uri = new Uri($"mailto:{email}?subject={subject}");
            Launcher.OpenAsync(uri);
        }

        //Command method to go back to course page
        private async void Back()
        {
            Debug.WriteLine("Proceed to Course Page");
            if (IsEditingAssessment)
            {
                IsEditingAssessment = false;
            }
            await Shell.Current.Navigation.PopAsync();
        }

        //Method to determine if assessment needs inserted or updated
        private async Task SaveAssessmentAsync()
        {
            //Check if assessment name is empty
            if (string.IsNullOrWhiteSpace(Assessment.AssessmentName))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Oops!", 
                    "Please enter an assessment name.", 
                    "OK");
                return;
            }

            //Date sanity checks
            if(Assessment.AssessmentStartDate > Assessment.AssessmentEndDate)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Oops!",
                    "Start date must be on or before end date.",
                    "OK");
                return;
            }

            if (Assessment.AssessmentStartDate < Course.CourseStartDate ||
                Assessment.AssessmentEndDate > Course.CourseEndDate)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Oops!",
                    "Assessment dates must be within course dates.",
                    "OK");
                return;
            }

            var overlaps = Assessments.Where(a => a.AssessmentID != Assessment.AssessmentID).Any(
                a => Assessment.AssessmentStartDate <= a.AssessmentEndDate &&
                     Assessment.AssessmentEndDate >= a.AssessmentStartDate);

            if (overlaps)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Oops!",
                    "Assessment dates overlap with another assessment.",
                    "OK");
                return;
            }
            
            //Insert or Update
            if (Assessment != null)
            {
                if (Assessment.AssessmentID == 0)
                {
                    await App.Database.InsertAssessmentAsync(Assessment);
                }
                else
                {
                    await App.Database.UpdateAssessmentAsync(Assessment);
                }
            }
            IsEditingAssessment = false;
        }

        //Property changed events to update view
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Notification methods
        private async Task AskAndScheduleNotifications()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet(
                "Notifications for this assessment",
                "Cancel",
                null,
                "Enable Start Reminder",
                "Enable Due Reminder",
                "Disable All");

            int startNotifId = Assessment.AssessmentID * 10 + 1;
            int dueNotifId = Assessment.AssessmentID * 10 + 2;

            switch(action)
            {
                case "Enable Start Reminder":
                    ScheduleNotification(
                        startNotifId,
                        $"Assessment \"{Assessment.AssessmentName}\" Begins",
                        Assessment.AssessmentStartDate);
                    break;

                case "Enable Due Reminder":
                    ScheduleNotification(
                        dueNotifId,
                        $"Assessment \"{Assessment.AssessmentName}\"Ends",
                        Assessment.AssessmentEndDate);
                    break;
            }
        }

        private void ScheduleNotification(int id, string title, DateTime targetDate)
        {
            //Notification can be scheduled for 10 seconds in the future for testing via DEBUG
#if DEBUG
            var notifyTime = DateTime.Now.AddSeconds(10);
#else
            var notifyTime = targetDate;
#endif
            if (!LocalNotificationCenter.Current.AreNotificationsEnabled().Result)
            {
                LocalNotificationCenter.Current.RequestNotificationPermission().Wait();
            }

            if (notifyTime <= DateTime.Now) return;

            var request = new NotificationRequest
            {
                NotificationId = id,
                Title = title,
                Description = $"On {notifyTime:MM/dd/yyyy}",
                ReturningData = assessment.AssessmentID.ToString(),
                
                Schedule =
                {
                    NotifyTime = notifyTime,
                    RepeatType = NotificationRepeat.No
                },
                
                Android = new AndroidOptions
                {
                    IconSmallName = new AndroidIcon
                    {
                        ResourceName = "icon_small"
                    },
                    ChannelId = "assessment-channel",
                    Priority = AndroidPriority.High
                }
            };
            
            LocalNotificationCenter.Current.Show(request);
        }
    }
}
