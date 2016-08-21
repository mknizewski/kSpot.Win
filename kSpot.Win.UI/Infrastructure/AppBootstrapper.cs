using Caliburn.Micro;
using kSpot.Win.UI.Interfaces;
using System;
using System.Windows;

namespace kSpot.Win.UI.Infrastructure
{
    public class AppBootstrapper : BootstrapperBase
    {
        private NinjectBindings _ninjectBindings;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _ninjectBindings = NinjectBindings.Create();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ILoginViewModel>();
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            _ninjectBindings.Dispose();
            base.OnExit(sender, e);
        }

        protected override object GetInstance(Type service, string key)
        {
            return _ninjectBindings.GetInstance(service);
        }
    }
}