using Caliburn.Micro;
using kSpot.Win.BOL.Attributes;
using kSpot.Win.BOL.Dictionaries;
using kSpot.Win.UI.Infrastructure;
using kSpot.Win.UI.Interfaces;
using kSpot.Win.UI.Views;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace kSpot.Win.UI.ViewModels
{
    public class LoginViewModel : BaseView<Screen>, ILoginViewModel
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

        protected override void Dispose()
        {
            base.Dispose();
        }

        [HistoryTracker(LoginViewModelDictionary.GoToRegisterPage)]
        public void GoToRegisterPage()
        {
            //TODO: Wszystko brać ze słownika
            //ResourceDictionary rd = new ResourceDictionary();
            //rd.Source = new Uri(LanguageDictionary.PolishLanguage, UriKind.Relative);

            //Application.Current.Resources.MergedDictionaries.Add(rd);
            var view = this.View.GetView();

            LoginView w = view as LoginView;
            var loadingGrid = w.LoadingScreen as Grid;
            loadingGrid.Visibility = Visibility.Visible;

            RegisterExecution(MethodInfo.GetCurrentMethod());
        }

        [HistoryTracker(LoginViewModelDictionary.LogToSystem)]
        public void LogToSystem()
        {
            var mainWindow = NinjectBindings.GetInstance<IMainWindowViewModel>();
            //TODO: Logika

            _windowManager.ShowWindow(mainWindow);
            View.TryClose();

            RegisterExecution(MethodInfo.GetCurrentMethod());
        }
    }
}