using Caliburn.Micro;
using kSpot.Win.DAL.Interfaces;
using kSpot.Win.UI.Interfaces;
using System;
using System.Windows;
using System.Windows.Threading;

namespace kSpot.Win.UI.Infrastructure
{
    public class AppBootstrapper : BootstrapperBase
    {
        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ILoginViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return NinjectBindings.GetInstance(service);
        }

        /// <summary>
        /// Metoda przechwytuje wszystkie wyjątki zgłoszone w programie i wysyła log do DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            IkSpotContext kSpotContext = NinjectBindings.GetInstance<IkSpotContext>();
            base.OnUnhandledException(sender, e);
        }
    }
}