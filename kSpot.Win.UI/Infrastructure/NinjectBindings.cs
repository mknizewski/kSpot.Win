using Caliburn.Micro;
using kSpot.Win.UI.Interfaces;
using kSpot.Win.UI.ViewModels;
using Ninject;
using System;

namespace kSpot.Win.UI.Infrastructure
{
    public static class NinjectBindings
    {
        private static IKernel Kernel = new StandardKernel();

        static NinjectBindings()
        {
            AddBindings();
        }

        /// <summary>
        /// W tej metodzie wstrzykujemy zależności
        /// </summary>
        private static void AddBindings()
        {
            Kernel.Bind<IMainWindowViewModel>().To<MainWindowViewModel>();
            Kernel.Bind<IWindowManager>().To<WindowManager>();
            Kernel.Bind<ILoginViewModel>().To<LoginViewModel>();
        }

        public static object GetInstance(Type serviceType)
        {
            return Kernel.Get(serviceType);
        }
    }
}