using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.LocalNotification;
using Plugin.LocalNotification.EventArgs;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace Barham_C971
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {

        // Prepares notifications for application
        protected override async void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            LocalNotificationCenter.Current.NotificationActionTapped += args =>
            {
                if (!args.IsTapped) return;
                var channel = args.Request.Android?.ChannelId;

                if (!int.TryParse(args.Request.ReturningData, out var id)) return;

                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    switch (channel)
                    {
                        case "assessment_channel":
                            await Shell.Current.GoToAsync("AssessmentPage?assessmentId={id}");
                            break;
                        case "course_channel":
                            await Shell.Current.GoToAsync("CoursePage?courseId={id}");
                            break;
                    }
                });

            };
            
        }
        
    }


}
