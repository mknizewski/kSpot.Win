using Caliburn.Micro;
using kSpot.Win.UI.Infrastructure;
using kSpot.Win.UI.Interfaces;
using kSpot.Win.UI.Properties;
using Ninject;
using System;
using System.Diagnostics;
using System.Windows;

namespace kSpot.Win.UI.ViewModels
{
    public class LoginViewModel : Screen, ILoginViewModel
    {
        private readonly IWindowManager _windowManager;

        public LoginViewModel(IWindowManager windowManager)
        {
            this._windowManager = windowManager;
        }

        public string Login
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Password
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool Remember
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool CanLogin()
        {
            throw new NotImplementedException();
        }

        public bool CheckCredentials()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }

        public void GoToRegisterPage()
        {
            //TODO: Wszystko brać ze słownika
            ResourceDictionary rd = new ResourceDictionary();
            rd.Source = new Uri("/Languages/Lang.pl-PL.xaml", UriKind.Relative);

            Application.Current.Resources.MergedDictionaries.Add(rd);
        }

        public void LogToSystem()
        {
            var mainWindow = NinjectBindings.Kernel.Get(typeof(IMainWindowViewModel));

            //TODO: Logika

            _windowManager.ShowWindow(mainWindow);
            TryClose();
        }
    }
}
