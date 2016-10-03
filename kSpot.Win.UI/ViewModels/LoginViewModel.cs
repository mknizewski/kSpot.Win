using Caliburn.Micro;
using kSpot.Win.BOL.Attributes;
using kSpot.Win.BOL.Dictionaries;
using kSpot.Win.BOL.Managers.LoginManager;
using kSpot.Win.UI.Infrastructure;
using kSpot.Win.UI.Interfaces;

namespace kSpot.Win.UI.ViewModels
{
    public class LoginViewModel : Screen, ILoginViewModel
    {
        private const int MinimumPasswordLength = 8;

        private readonly IWindowManager _windowManager;
        private readonly ILoginManager _loginManager;

        private string _login;
        private string _password;
        private bool _remember;

        public LoginViewModel(IWindowManager windowManager, ILoginManager loginManager)
        {
            this._windowManager = windowManager;
            this._loginManager = loginManager;
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
                return _remember;
            }

            set
            {
                _remember = value;
            }
        }

        public bool CanLogToSystem
        {
            get { return CanLog(); }
        }

        public bool CanLog()
        {
            if (!string.IsNullOrEmpty(Login))
                return _loginManager.ValidatePasswordByPattern(Password);

            return false;
        }

        [HistoryTracker(LoginViewModelDictionary.GoToRegisterPage)]
        public void GoToRegisterPage()
        {

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

        public void Dispose()
        {
            _loginManager.Dispose();
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);

            if (close)
                Dispose();
        }
    }
}