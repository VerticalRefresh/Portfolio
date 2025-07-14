using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Barham_C971.DataClasses;
using Microsoft.Maui.Controls;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Dispatching;
using SQLite;

namespace Barham_C971.ViewModels
{
    public class TermsViewModel : INotifyPropertyChanged
    {
        //Tracks selected term on main page
        private Term selectedTerm;
        //Tracks if term is being edited
        private bool isEditingTerm;
        //Tracks all terms in database for logged in student
        public int StudentID { get; set; }
        public string TermName { get; set; }
        public ObservableCollection<Term> Terms { get; set; } = new ObservableCollection<Term>();

        //Tracks if term is being edited
        public bool IsEditingTerm
        {
            get => isEditingTerm;
            set
            {
                if (isEditingTerm != value)
                {
                    isEditingTerm = value;
                    OnPropertyChanged();
                }
            }
        }

        //Constructor for selected term
        public Term SelectedTerm
        {
            get => selectedTerm;
            set
            {
                if (selectedTerm == value)
                    return;

                //Control property changed event subscription to avoid null reference exceptions
                if (selectedTerm != null)
                {
                    selectedTerm.PropertyChanged -= OnTermPropertyChanged;
                }

                selectedTerm = value;

                //Update UI
                OnPropertyChanged();

                //Notify UI of term selection change
                NotifyTermSelectionChanged();

                //Validates 6 month terms from start of month to end of 6 months
                if (selectedTerm != null)
                {
                    SyncTermDates(selectedTerm);
                    selectedTerm.PropertyChanged += OnTermPropertyChanged;
                }

                //Load Courses
                LoadSelectedTermCourses();
            }
        }

        //Loads courses for selected term
        private async void LoadSelectedTermCourses()
        {
            //Kill switch for null term
            if (selectedTerm == null) return;

            //Get Courses
            var courses = await App.Database.GetCoursesForTermAsync(selectedTerm.TermID);

            //Reset Courses
            selectedTerm.Courses.Clear();

            //Add Courses to Term
            foreach (var course in courses)
            {
                selectedTerm.Courses.Add(course);
            }
        }

        //Notifies UI of term selection change
        void NotifyTermSelectionChanged()
        {
            foreach (var t in Terms)
            {
                t.IsSelected = t == selectedTerm;
            }
        }

        //Syncs the terms to 6 months from the start of the month
        private void OnTermPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Term.TermStartDate))
            {
                var term = (Term)sender;
                term.PropertyChanged -= OnTermPropertyChanged;
                SyncTermDates(term);
                term.PropertyChanged += OnTermPropertyChanged;
            }
        }

        //Term sync logic for property changed
        void SyncTermDates(Term term)
        {
            var dt = term.TermStartDate;
            var first = new DateTime(dt.Year, dt.Month, 1);
            if (dt != first)
            {
                term.TermStartDate = first;
            }
            term.TermEndDate = first.AddMonths(7).AddDays(-1);
        }

        //Command Constructors
        public ICommand AddTermCommand { get; }

        public ICommand SaveTermCommand { get; }

        public ICommand CancelTermCommand { get; }

        public ICommand EditTermCommand { get; }

        public ICommand DeleteTermCommand { get; }
        public ICommand AddCourseCommand { get; }
        public ICommand DeleteCourseCommand { get; }
        public ICommand EditCourseCommand { get; set; }

        public TermsViewModel()
        {
            AddTermCommand = new Command(AddTerm);
            SaveTermCommand = new Command(async () => await SaveTermAsync());
            CancelTermCommand = new Command(() => Cancel());
            EditTermCommand = new Command(() => EditTerm());
            DeleteTermCommand = new Command(() => DeleteTerm()); 
            AddCourseCommand = new Command(() => AddCourse());
            DeleteCourseCommand = new Command<Course> (async course => await ConfirmAndDeleteCourseAsync(course));
            EditCourseCommand = new Command<Course>(async course =>
            {
                await Shell.Current.GoToAsync($"CoursePage?courseId={course.CourseID}&termId={SelectedTerm.TermID}&edit=true");
            });
        }

        //Initializes the view model and loads terms from the database
        public async Task InitializeAsync() => await LoadTermsAsync();


        //Loads all terms from database and sets selected term to the first term in the list
        private async Task LoadTermsAsync()
        {
            var termList = await App.Database.GetTermsForStudentAsync(StudentID);

            Terms.Clear(); // Clear existing terms before adding new ones

            foreach (var term in termList)
            {
                term.Courses = await App.Database.GetCoursesForTermAsync(term.TermID);
                MainThread.BeginInvokeOnMainThread(() => Terms.Add(term)); 
            }
            
            if (Terms.Count > 0)
            {
                SelectedTerm = Terms[0]; // Select the first term by default
            }
        }

        //Command Methods

        //Adds a course to the selected term
        private async Task AddCourse()
        {
            if (SelectedTerm != null)
            {
                Debug.WriteLine($"Selected term: {SelectedTerm.TermID}");
                await Shell.Current.GoToAsync($"CoursePage?courseId=0&termId={SelectedTerm.TermID}");
            }
        }

        //Adds a new term to the list
        private void AddTerm()
        {
            var newTerm = new Term
            {
                TermName = "New Term",
                TermStartDate = DateTime.Now,
                TermEndDate = DateTime.Now.AddMonths(7).AddDays(-1),
                Courses = new ObservableCollection<Course>(),
                StudentID = this.StudentID
            };
            Terms.Add(newTerm);
            SelectedTerm = newTerm;
            IsEditingTerm = true;
        }

        //Cancels the current term edit and removes the term from the list
        private void Cancel()
        {
            IsEditingTerm = false;
            if (SelectedTerm != null && Terms.Contains(SelectedTerm))
            {
                Terms.Remove(SelectedTerm);
            }
        }

        //Edits the selected term
        private void EditTerm()
        {
            if (SelectedTerm != null)
            {
                IsEditingTerm = true;
            }  
        }

        //Confirms and deletes the selected course
        private async Task ConfirmAndDeleteCourseAsync(Course course)
        {
            bool ok = await Application.Current.MainPage.DisplayAlert(
                "Delete Course",
                $"Are you sure you want to delete the course '{course.CourseName}'?",
                "Yes",
                "No");
            if (!ok) return;
            App.Database.DeleteCourseAsync(course);
            SelectedTerm.Courses.Remove(course);
        }
        //Deletes the selected term from the list and database
        private async Task DeleteTerm()
        {
            if (SelectedTerm != null)
            {
                bool ok = await Application.Current.MainPage.DisplayAlert(
                    "Delete Term",
                    $"Are you sure you want to delete the term '{SelectedTerm.TermName}' and all of it's courses?",
                    "Yes",
                    "No");
                if (!ok) return;


                Terms.Remove(SelectedTerm);
                App.Database.DeleteTermAsync(SelectedTerm);
                SelectedTerm = Terms[0] as Term;
            }
        }

        //Saves the current term to the database and validates the term name and dates
        private async Task SaveTermAsync()
        {
            if (SelectedTerm != null)
            {
                if (string.IsNullOrWhiteSpace(SelectedTerm.TermName))
                {
                    await App.Current.MainPage.DisplayAlert(
                        "Oops!", 
                        "Please enter a term name.", 
                        "OK");
                    return;
                }

                var terms = await App.Database.GetTermsForStudentAsync(StudentID);
                var overlap = terms
                    .Where(t => t.TermID != SelectedTerm.TermID &&
                    SelectedTerm.TermStartDate <= t.TermEndDate &&
                    SelectedTerm.TermEndDate >= t.TermStartDate);

                if (overlap.Any())
                {
                    await App.Current.MainPage.DisplayAlert(
                        "Oops!",
                        "The term dates overlap with another term.",
                        "OK");
                    return;
                }


                    if (SelectedTerm.TermID == 0)
                {
                    await App.Database.InsertTermAsync(SelectedTerm);
                }
                else
                {
                    await App.Database.UpdateTermAsync(SelectedTerm);
                }
                IsEditingTerm = false;
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
