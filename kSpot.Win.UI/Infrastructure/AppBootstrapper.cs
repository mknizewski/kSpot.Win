using Caliburn.Micro;
using kSpot.Win.UI.ViewModels;
using System.Windows;

namespace kSpot.Win.UI.Infrastructure
{
    public class AppBootstrapper : BootstrapperBase
    {
        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainWindowViewModel>();
        }
    }
}