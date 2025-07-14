
using Barham_C971.ViewModels;
using System.Diagnostics;
using System.Threading.Tasks;
using Barham_C971.DataClasses;
namespace Barham_C971.Pages


{
    public partial class MainPage : ContentPage, IQueryAttributable
    {
        TermsViewModel vm => BindingContext as TermsViewModel;
        //Initialize and set BindingContext
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new TermsViewModel();
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {

            //Check if the query contains a student ID
            int studentId = 0;
            if (query.TryGetValue("studentId", out object studentIdObj))
            {
                if (studentIdObj is string studentIdString && int.TryParse(studentIdString, out int parsedStudentId))
                {
                    Debug.WriteLine($"Student ID passed into MainPage: {parsedStudentId}");
                    studentId = parsedStudentId;
                }
                else if (studentIdObj is int studentIdInt)
                {
                    Debug.WriteLine($"Student ID passed into MainPage: {studentIdInt}");
                    studentId = studentIdInt;
                }
                var vm = (TermsViewModel)BindingContext;
                vm.StudentID = studentId;
                await vm.InitializeAsync();
            }
        }

        //When the user taps on a term, set the selected term in the ViewModel
        private void OnTermTabTapped(object sender, Term term)
        {
            if (BindingContext is TermsViewModel viewModel)
            {
                viewModel.SelectedTerm = term;
            }
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var vm = (TermsViewModel)BindingContext;
            //Check if the ViewModel is already initialized
            if (vm.SelectedTerm != null)
            {
                vm.SelectedTerm.Courses.Clear();
                var courses = await App.Database.GetCoursesForTermAsync(vm.SelectedTerm.TermID);
                foreach (var course in courses)
                {
                    vm.SelectedTerm.Courses.Add(course);
                }

            }
        }
    }
}
