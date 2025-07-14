using System.Diagnostics;

namespace Barham_C971
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Register routes for navigation
            Routing.RegisterRoute("LoginPage", typeof(Barham_C971.Pages.Login));
            Routing.RegisterRoute("CoursePage", typeof(Barham_C971.Pages.CoursePage));
            Routing.RegisterRoute("AssessmentPage", typeof(Barham_C971.Pages.AssessmentPage));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Shell.Current.GoToAsync("LoginPage");
        }

    }
}
