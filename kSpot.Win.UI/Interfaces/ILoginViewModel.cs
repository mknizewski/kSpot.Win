namespace kSpot.Win.UI.Interfaces
{
    public interface ILoginViewModel
    {
        string Login { get; set; }
        string Password { get; set; }
        bool Remember { get; set; }

        bool CheckCredentials();

        void GoToRegisterPage();

        void LogToSystem();

        bool CanLogin();

        void Dispose();
    }
}