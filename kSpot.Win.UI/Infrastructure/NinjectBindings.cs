using Caliburn.Micro;
using kSpot.Win.UI.Interfaces;
using kSpot.Win.UI.ViewModels;
using Ninject;
using System;

namespace kSpot.Win.UI.Infrastructure
{
    public class NinjectBindings
    {
        private IKernel _container;

        private NinjectBindings()
        {
            this._container = new StandardKernel();
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
            this._container.Bind<IMainWindowViewModel>().To<MainWindowViewModel>();
            this._container.Bind<IWindowManager>().To<WindowManager>();
        }

        public object GetInstance(Type serviceType)
        {
            return _container.Get(serviceType);
        }
    }
}
