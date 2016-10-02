using Caliburn.Micro;
using kSpot.Win.BOL.Attributes;
using kSpot.Win.BOL.Dictionaries;
using kSpot.Win.UI.Infrastructure;
using kSpot.Win.UI.Interfaces;
using kSpot.Win.UI.Views;
using System;
using System.Windows;
using System.Windows.Controls;

namespace kSpot.Win.UI.ViewModels
{
    public class LoginViewModel : Screen, ILoginViewModel
    {
        private const int MinimumPasswordLength = 8;

        private readonly IWindowManager _windowManager;
        private string _login;
        private string _password;
        private bool _remember;

        public LoginViewModel(IWindowManager windowManager)
        {
            this._windowManager = windowManager;
        }

        public string Login
        {
            get
            {
                return _login;
            }

            set
            {
                _login = value;
                NotifyOfPropertyChange(() => Login);
                NotifyOfPropertyChange(() => CanLogToSystem);
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogToSystem);
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

        public bool CanLogToSystem
        {
            get { return CanLog(); }
        }

        public bool CanLog()
        {
            if (!string.IsNullOrEmpty(Login))
            {
                if (!string.IsNullOrEmpty(Password))
                    if (Password.Length >= MinimumPasswordLength)
                        return true;
            }

            return false;
        }

        public bool CheckCredentials()
        {
            throw new NotImplementedException();
        }

        [HistoryTracker(LoginViewModelDictionary.GoToRegisterPage)]
        public void GoToRegisterPage()
        {
            //TODO: Wszystko brać ze słownika
            //ResourceDictionary rd = new ResourceDictionary();
            //rd.Source = new Uri(LanguageDictionary.PolishLanguage, UriKind.Relative);

            //Application.Current.Resources.MergedDictionaries.Add(rd);

            var view = GetView();
            LoginView w = view as LoginView;
            var loadingGrid = w.LoadingScreen as Grid;
            loadingGrid.Visibility = Visibility.Visible;

            //RegisterExecution(MethodInfo.GetCurrentMethod());
        }

        [HistoryTracker(LoginViewModelDictionary.LogToSystem)]
        public void LogToSystem()
        {
            var mainWindow = NinjectBindings.GetInstance<IMainWindowViewModel>();
            //TODO: Logika

            _windowManager.ShowWindow(mainWindow);
            TryClose();

            //RegisterExecution(MethodInfo.GetCurrentMethod());
        }
    }
}