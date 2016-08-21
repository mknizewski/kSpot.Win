using Caliburn.Micro;
using kSpot.Win.UI.Interfaces;
using kSpot.Win.UI.ViewModels;
using Ninject;
using System;

namespace kSpot.Win.UI.Infrastructure
{
    public class NinjectBindings : IDisposable
    {
        public static IKernel Kernel;

        private NinjectBindings()
        {
            Kernel = new StandardKernel();
            AddBindings();
        }

        public static NinjectBindings Create()
        {
            return new NinjectBindings();
        }

        /// <summary>
        /// W tej metodzie wstrzykujemy zależności
        /// </summary>
        private void AddBindings()
        {
            Kernel.Bind<IMainWindowViewModel>().To<MainWindowViewModel>();
            Kernel.Bind<IWindowManager>().To<WindowManager>();
            Kernel.Bind<ILoginViewModel>().To<LoginViewModel>();
        }

        public object GetInstance(Type serviceType)
        {
            return Kernel.Get(serviceType);
        }

        public void Dispose()
        {
            Kernel.Dispose();
        }
    }
}
