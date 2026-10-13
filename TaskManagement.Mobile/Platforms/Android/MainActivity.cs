using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App;
using Plugin.Firebase.CloudMessaging;

namespace TaskManagement.Mobile
{
    [Activity(
        Theme = "@style/Maui.SplashTheme",
        MainLauncher = true,
        LaunchMode = LaunchMode.SingleTop,
        ConfigurationChanges = ConfigChanges.ScreenSize |
                               ConfigChanges.Orientation |
                               ConfigChanges.UiMode |
                               ConfigChanges.ScreenLayout |
                               ConfigChanges.SmallestScreenSize |
                               ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            CreateNotificationChannel();
        }

        private void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
                return;

            var channelId = $"{PackageName}.general";

#pragma warning disable CA1416 
            var channel = new NotificationChannel(
                channelId,
                "General",
                NotificationImportance.High);
#pragma warning restore CA1416

            var notificationManager =
                (NotificationManager)GetSystemService(NotificationService)!;

            notificationManager.CreateNotificationChannel(channel);

            FirebaseCloudMessagingImplementation.ChannelId = channelId;
        }
    }
}