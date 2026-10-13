using Android;
using Microsoft.Maui.ApplicationModel;

namespace TaskManagement.Mobile.Platforms.Android;

public class NotificationPermission : Permissions.BasePlatformPermission
{
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions
    {
        get
        {
            if (OperatingSystem.IsAndroidVersionAtLeast(33))
            {
                return
                [
                    (Manifest.Permission.PostNotifications, true)
                ];
            }

            return [];
        }
    }
}