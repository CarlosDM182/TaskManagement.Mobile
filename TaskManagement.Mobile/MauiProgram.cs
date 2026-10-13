using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
#if ANDROID
using Plugin.Firebase.Core.Platforms.Android;
using Plugin.Firebase.Crashlytics;

#endif
using TaskManagement.Mobile.Services;
using TaskManagement.Mobile.Services.Interfaces;
using TaskManagement.Mobile.ViewModels;
using TaskManagement.Mobile.Views;

namespace TaskManagement.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .RegisterFirebaseServices()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // Services
        builder.Services.AddSingleton<ITokenService, TokenService>();
        builder.Services.AddTransient<AuthTokenHandler>();

        builder.Services.AddHttpClient<IApiClient, ApiClient>(client =>
        {
            client.BaseAddress = new Uri("http://192.168.1.9:8080/");
        })
        .AddHttpMessageHandler<AuthTokenHandler>();

        builder.Services.AddTransient<IAuthService, AuthService>();
        builder.Services.AddTransient<ITaskService, TaskService>();
        builder.Services.AddTransient<FirebaseNotificationService>();


        // Application Services
        builder.Services.AddTransient<IAuthService, AuthService>();
        builder.Services.AddTransient<ITaskService, TaskService>();

        // ViewModels
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<TaskViewModel>();
        builder.Services.AddTransient<TaskDetailViewModel>();
        builder.Services.AddTransient<EditTaskViewModel>();

        // Views
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<TaskPage>();
        builder.Services.AddTransient<TaskDetailPage>();
        builder.Services.AddTransient<EditTaskPage>();

        return builder.Build();
    }

    private static MauiAppBuilder RegisterFirebaseServices(
    this MauiAppBuilder builder)
    {
        builder.ConfigureLifecycleEvents(events =>
        {
#if ANDROID
            events.AddAndroid(android =>
                android.OnCreate((activity, _) =>
                {
                    CrossFirebase.Initialize(
                        activity,
                        () => Platform.CurrentActivity);
                    CrossFirebase.Initialize(activity, () => Platform.CurrentActivity);
                    CrossFirebaseCrashlytics.Current.SetCrashlyticsCollectionEnabled(true);

                    var firebaseNotificationService =
                        IPlatformApplication.Current?.Services
                            .GetService<FirebaseNotificationService>();

                    firebaseNotificationService?.Initialize();
                }));
#endif
        });

        return builder;
    }
}