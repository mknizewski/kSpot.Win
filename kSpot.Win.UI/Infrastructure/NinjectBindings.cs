using Caliburn.Micro;
using kSpot.Win.DAL.Context;
using kSpot.Win.DAL.Interfaces;
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
            Kernel.Bind<IScreen>().To<Screen>();
        }

        public static T GetInstance<T>()
        {
            return Kernel.Get<T>();
        }

        public static object GetInstance(Type type)
        {
            return Kernel.Get(type);
        }
    }
}