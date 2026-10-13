using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Mobile.Routes;
using TaskManagement.Mobile.Views;

namespace TaskManagement.Mobile 
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            RouteConfig.RegisterRoutes();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}