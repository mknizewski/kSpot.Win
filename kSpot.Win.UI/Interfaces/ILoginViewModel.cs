using System;

namespace kSpot.Win.UI.Interfaces
{
    public interface ILoginViewModel : IDisposable
    {
        string Login { get; set; }
        string Password { get; set; }
        bool Remember { get; set; }

        void GoToRegisterPage();

        void LogToSystem();

        bool CanLog();
    }
}