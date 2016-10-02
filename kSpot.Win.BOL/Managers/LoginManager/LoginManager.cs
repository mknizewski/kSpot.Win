using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace kSpot.Win.BOL.Managers.LoginManager
{
    public class LoginManager : ILoginManager
    {
        private const int MinimumPasswordSize = 8;
        private const string PasswordPatternDigital = @"\d";
        private const string PasswordPatternUpperCase = @"[A-Z]";

        public LoginManager()
        {

        }

        public bool AuthorizeLogin()
        {
            throw new NotImplementedException();
        }

        public bool CheckCredinetials()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            
        }

        public bool ValidatePasswordByPattern(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                if (password.Length >= MinimumPasswordSize)
                    return Regex.IsMatch(password, PasswordPatternDigital) || Regex.IsMatch(password, PasswordPatternUpperCase);
            }

            return false;
        }
    }
}
