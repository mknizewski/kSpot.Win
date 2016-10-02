using System;

namespace kSpot.Win.BOL.Managers.LoginManager
{
    public interface ILoginManager : IDisposable
    {
        bool CheckCredinetials();

        bool AuthorizeLogin();

        bool ValidatePasswordByPattern(string password);
    }
}