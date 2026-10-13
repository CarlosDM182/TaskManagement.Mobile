using TaskManagement.Mobile.Views;

namespace TaskManagement.Mobile.Routes;

public static class RouteConfig
{
    public static void RegisterRoutes()
    {
        Routing.RegisterRoute(nameof(AppRoute.Task), typeof(TaskPage));
        Routing.RegisterRoute(nameof(AppRoute.TaskDetail), typeof(TaskDetailPage));
        Routing.RegisterRoute(nameof(AppRoute.EditTask), typeof(EditTaskPage));

    }
}