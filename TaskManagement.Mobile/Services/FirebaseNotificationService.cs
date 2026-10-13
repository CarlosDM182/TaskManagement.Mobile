#if ANDROID
using Plugin.Firebase.CloudMessaging;
using Plugin.Firebase.CloudMessaging.EventArgs;
using Plugin.Firebase.Crashlytics;
using static Android.Provider.Settings;
#endif

namespace TaskManagement.Mobile.Services;

public class FirebaseNotificationService
{
    public async Task<string?> GetTokenAsync()
    {
#if ANDROID
        await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();

        return await CrossFirebaseCloudMessaging.Current.GetTokenAsync();
#else
        return null;
#endif
    }

#if ANDROID
    public async void Initialize()
    {
        var token = await GetTokenAsync();
        System.Diagnostics.Debug.WriteLine($"FCM : TOKEN {token}");
        CrossFirebaseCloudMessaging.Current.NotificationReceived += OnNotificationReceived;

        CrossFirebaseCrashlytics.Current.RecordException(
    new Exception("Prueba de Crashlytics"));

    }

    private void OnNotificationReceived(object ? sender, FCMNotificationReceivedEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine(
                $"FCM: {e.Notification?.Title} - {e.Notification?.Body}");
    }
#endif
}