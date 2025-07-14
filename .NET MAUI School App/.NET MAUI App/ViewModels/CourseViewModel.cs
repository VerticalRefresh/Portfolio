using System.ComponentModel;
using Barham_C971.DataClasses;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;
using System.Net.Mail;




namespace Barham_C971.ViewModels
{
    public class CourseViewModel : INotifyPropertyChanged
    {
        //Term ID to track the term that the course is assigned to, which tracks the student the term is assigned to
        public int TermID { get; set; }

        //Tracks selected course on main page
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

        //Instructor for course
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

        //Course Assessments
        private ObservableCollection<Assessment> assessments = new();
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

        //List of all instructors
        public ObservableCollection<Instructor> AllInstructors { get; } = new();

        //Tracks selected instructor
        Instructor selectedInstructor;
        public Instructor SelectedInstructor
        {
            get => selectedInstructor;
            set
            {
                if (selectedInstructor != value)
                {
                    selectedInstructor = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsEditingInstructor));
                }
            }
        }

        //Tracks if instructor is being edited
        private bool isEditingInstructor;
        public bool IsEditingInstructor
        {
            get => isEditingInstructor;
            set
            {
                if (isEditingInstructor != value)
                {
                    isEditingInstructor = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsEditingCombined));
                }
            }
        }

        //Tracks if course is being edited
        private bool isEditingCourse;
        public bool IsEditingCourse
        {
            get => isEditingCourse;
            set
            {
                if (isEditingCourse != value)
                {
                    isEditingCourse = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsEditingCombined));
                }
            }
        }

        //Tracks if either course or instructor is being edited
        //Uses onpropertychanged to check in real time
        public bool IsEditingCombined => IsEditingInstructor || IsEditingCourse;

        //Course Status Options
        public IReadOnlyList<String> StatusOptions { get; } = new[]
        {
            "Not Registered",
            "Registered",
            "In Progress",
            "Completed",
            "Dropped"
        };

        //Load course data from database
        public async Task LoadCourseDataAsync(int courseId, int termId = 0)
        {
            TermID = termId;
            
            //Load dummy data for new course
            if (courseId == 0)
            {
                Course = new Course
                {
                    CourseID = 0,
                    TermID = TermID,
                    InstructorID = 0,
                    CourseName = "New Course",
                    CourseStatus = "In Progress",
                    CourseNotes = "Notes",
                    CourseStartDate = DateTime.Now,
                    CourseEndDate = DateTime.Now.AddMonths(7).AddDays(-1)
                };
                IsEditingCourse = true;
            }
            //Load existing course data
            else 
            { 
                Course = await App.Database.GetCourseAsync(courseId);
            }

            //Load dummy data for new instructor
            if (Course.InstructorID == 0)
            {
                Instructor = new Instructor
                {
                    InstructorID = 0,
                    InstructorName = "New Instructor",
                    InstructorEmail = "Email",
                    InstructorPhone = "Phone"
                };
                IsEditingInstructor = true;
            }
            
            //Load existing instructor data
            else
            {
                Instructor = await App.Database.GetInstructorAsync(Course.InstructorID);
            }

            //Load all instructors from database
            var instructorList = await App.Database.GetInstructorsAsync();
            AllInstructors.Clear();
            foreach (var instructor in instructorList)
            {
                AllInstructors.Add(instructor);
            }
            
            //Set the selected instructor to the current instructor
            SelectedInstructor = AllInstructors.FirstOrDefault(i => i.InstructorID == Course.InstructorID) ?? AllInstructors[0]; 
            
            // Clear the existing assessments before loading new ones
            Assessments.Clear(); 

            var assessmentList = await App.Database.GetAssessmentsByCourseIdAsync(courseId);
            
            //Populates the assessmentList for collectionView
            foreach (var assessment in assessmentList)
            {
                Assessments.Add(assessment);
            }
        }
        
        //Loads commands for course page
        public CourseViewModel()
        {
            // Initialize commands
            CancelEditCommand = new Command(CancelEdit);
            EditInstructorCommand = new Command(EditInstructor);
            EditCourseCommand = new Command(EditCourse);
            SaveCommand = new Command(async () => await ValidateAndSaveAsync());
            AddAssessmentCommand = new Command(AddAssessment);
            BackCommand = new Command(Back);
            HomeCommand = new Command(Home);
            ToggleNotificationsCommand = new Command(async () => await ToggleNotifications());
            OnEmailLabelTappedCommand = new Command(OnEmailLabelTapped);
            OnPhoneLabelTappedCommand = new Command(OnPhoneLabelTapped);
            SelectInstructorCommand = new Command(async () => SelectInstructorAsync());
            ShareNotesCommand = new Command(async () => await ShareNotesAsync());

        }

        //Commands
        public ICommand SaveCommand { get; }
        public ICommand CancelEditCommand { get; }
        public ICommand EditInstructorCommand { get; }
        public ICommand EditCourseCommand { get; }
        public ICommand AddAssessmentCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand HomeCommand { get; }
        public ICommand ToggleNotificationsCommand { get; }
        public ICommand OnEmailLabelTappedCommand { get; }
        public ICommand OnPhoneLabelTappedCommand { get; }
        public ICommand SelectInstructorCommand { get; }
        public ICommand ShareNotesCommand { get;  }

        //Save instructor
        private async Task ValidateAndSaveAsync()
        {
            Instructor = SelectedInstructor;
            Debug.WriteLine("ValidateAndSaveAsync called");
            //Name Validations
            if (string.IsNullOrWhiteSpace(Course.CourseName))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Oops!",
                    "Course name cannot be empty.",
                    "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(Instructor.InstructorName))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Oops!",
                    "Instructor must have a name!",
                    "Ok");
                return;
            }
            
            //Email Validation
            try
            {
                  _ = new System.Net.Mail.MailAddress(Instructor.InstructorEmail);
            }
            catch (FormatException)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Oops!",
                    "Instructor must have a valid email address!",
                    "Ok");
                return;
            }

            //Phone  Validation
            var digits = new string(Instructor.InstructorPhone.Where(char.IsDigit).ToArray());

            if (digits.Length != 10)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Oops!",
                    "Instructor must have a valid phone number!",
                    "Ok");
                return;
            }

            Instructor.InstructorPhone =
                $"({digits.Substring(0, 3)})" +
                $"{digits.Substring(3, 3)}-" +
                $"{digits.Substring(6, 4)}";

            //Date Validations
            if (Course.CourseStartDate > Course.CourseEndDate)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Oops!",
                    "Course start date cannot be after the end date.",
                    "OK");
                return;
            }

            var term = await App.Database.GetTermAsync(TermID);

            if (Course.CourseStartDate < term.TermStartDate || Course.CourseEndDate > term.TermEndDate)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Oops!",
                    "Course dates must be within the term dates.",
                    "OK");
                return;
            }

            if (Course.CourseStartDate > Course.CourseEndDate)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Oops!",
                    "Course start date cannot be after the end date.",
                    "OK");
                return;
            }

            var termCourses = await App.Database.GetCoursesForTermAsync(TermID);
            var overlaps = termCourses
                .Where(c => c.CourseID != Course.CourseID
                && c.CourseStartDate <= Course.CourseEndDate
                && c.CourseEndDate >= Course.CourseStartDate)
                .ToList();

            if (overlaps.Any())
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Oops!",
                    "Course dates overlap with another course in the same term.",
                    "OK");
                return;
            }

            //Save Instructor

            //Insert a new instructor if InstructorID = 0
            if (Instructor.InstructorID == 0)
            {
                Debug.WriteLine("Instructor ID 0, saving new instructor");
                await App.Database.InsertInstructorAsync(Instructor);
                Course.InstructorID = Instructor.InstructorID;
            }
            else
            //Updates an instructor with an existing DB ID
            {
                Debug.WriteLine($"Updating Instructor ID {Instructor.InstructorID}");
                await App.Database.UpdateInstructorAsync(Instructor);
            }
            //Turn off Editing
            IsEditingInstructor = false;

            Course.TermID = TermID;
            
            //Insert a new course if CourseID = 0
            if (Course.CourseID == 0)
            {
                Debug.WriteLine($"Course ID 0, saving new course with TermID {Course.TermID}");
                await App.Database.InsertCourseAsync(Course);
            }
            else
            //Update existing course
            {
                Debug.WriteLine($"Updating course ID {Course.CourseID}");
                await App.Database.UpdateCourseAsync(Course);
            }
            //Turn off editing
            IsEditingCourse = false;
        }

        async Task SelectInstructorAsync()
        {
            //Gets the list of instructors and adds them to a pick list for selection
            var namesList = AllInstructors.Select(i => i.InstructorName).ToList();
            namesList.Add("New Instructor");
            var pick = await Application.Current.MainPage.DisplayActionSheet("Select Instructor", "Cancel", null, namesList.ToArray());
            
            if (pick == "Cancel" || pick == null)
            {
                return;
            }

            //If the user selects "New Instructor", create a new instructor object
            if (pick == "New Instructor")
            {
                var fresh = new Instructor
                {
                    InstructorID = 0,
                    InstructorName = "New Instructor",
                    InstructorEmail = "Email",
                    InstructorPhone = "Phone"
                };
                AllInstructors.Add(fresh);

                Instructor = fresh;
                SelectedInstructor = fresh;

                IsEditingInstructor = true;
            }
            else
            //If the user selects an existing instructor, set the selected instructor to that instructor
            {
                var inst = AllInstructors.FirstOrDefault(i => i.InstructorName == pick);
                if (inst != null)
                {
                    SelectedInstructor = inst;
                    Instructor = SelectedInstructor;
                }
            }
        }

        // Cancel edit mode for both course and instructor
        private void CancelEdit()
        {
            IsEditingCourse = false;
            IsEditingInstructor = false;
        }

        // Turns on editing instructor using Mode=TwoWay to modify instructor object
        private void EditInstructor()
        {
            IsEditingInstructor = true;
        }

        // Turns on editing course using Mode=TwoWay to modify course object
        private void EditCourse()
        {
            IsEditingCourse = true;
        }

        // Add new assessment with ID 0 to trigger new assessment logic
        private async void AddAssessment()
        {
            await Shell.Current.GoToAsync($"AssessmentPage?courseId={Course.CourseID}&assessmentId=0");
        }

        // Navigate back to the previous page
        private async void Back()
        {
            if (IsEditingCourse || IsEditingInstructor)
            {
                CancelEdit();
            }
            Debug.WriteLine("CoursePage Back invoked, popping one page");
            await Shell.Current.Navigation.PopAsync();
        }

        // Navigate to the home page
        private async void Home()
        {
            if (IsEditingCourse || IsEditingInstructor)
            {
                CancelEdit();
            }
            await Shell.Current.Navigation.PopToRootAsync();
        }

        // Open email client
        private void OnEmailLabelTapped()
        {
            var email = Instructor.InstructorEmail;
            var subject = $"Course Inquiry, {Course.CourseName}";
            var uri = new Uri($"mailto:{email}?subject={subject}");
            Launcher.OpenAsync(uri);
        }

        // Open phone dialer
        private void OnPhoneLabelTapped()
        {
            var phone = Instructor.InstructorPhone;
            var uri = new Uri($"tel:{phone}");
            Launcher.OpenAsync(uri);
        }

        //Share notes

        private async Task ShareNotesAsync()
        {
            if (string.IsNullOrWhiteSpace(Course?.CourseNotes))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Nothing to share",
                    "There are no notes in this course yet.",
                    "OK");
                return;
            }

            var request = new ShareTextRequest
            {
                Title = $"Notes for '{Course.CourseName}'",
                Text = Course.CourseNotes,
            };

            await Share.RequestAsync(request);
        }

        //Notification methods
        private async Task ToggleNotifications()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet(
                "Notifications for this course",
                "Cancel",
                null,
                "Enable Start Reminder",
                "Enable End Reminder",
                "Disable All"
                );

            int startNotifId = Course.CourseID * 10 + 1;
            int endNotifId = Course.CourseID * 10 + 2;

            switch(action)
            {
                case "Enable Start Reminder":
                    ScheduleNotification(
                        startNotifId,
                        $"Course \"{Course.CourseName}\" starts today!",
                        Course.CourseStartDate);
                    break;
                
                case "Enable End Reminder":
                    ScheduleNotification(
                        endNotifId,
                        $"Course \"{Course.CourseName}\" ends today!",
                        Course.CourseEndDate);
                    break;
                //****Check if notifications are disabled by doing this****
                case "Disable All":
                    break;
            }
        }

        private void ScheduleNotification(int id, string title, DateTime targetDate)
        {
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
                ReturningData = id.ToString(),

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
                    ChannelId = "course-channel",
                    Priority = AndroidPriority.High
                }
            };
            LocalNotificationCenter.Current.Show(request);
        }

        //INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Debug.WriteLine($"Property changed: {propertyName}"); // Debugging line
        }
    }
}
