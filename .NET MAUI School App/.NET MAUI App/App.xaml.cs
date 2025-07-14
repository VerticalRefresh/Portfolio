using Barham_C971.DataClasses;
using Microsoft.Maui.Dispatching;

namespace Barham_C971
{
    public partial class App : Application
    {
        public static DatabaseService Database { get; private set; }
        public App()
        {
            InitializeComponent();

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "database.db");
            Database = new DatabaseService(dbPath);

            Task.Run(async () =>
            {
                await Database.InitializeAsync();
            });


        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(100); // Delay to ensure database is initialized
                await Shell.Current.GoToAsync("//Login");
            });
            return window;
        }


    }
}