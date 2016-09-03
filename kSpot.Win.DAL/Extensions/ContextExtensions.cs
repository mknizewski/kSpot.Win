using Cryptography;
using System.Configuration;

namespace kSpot.Win.DAL.Extensions
{
    public static class ContextExtensions
    {
        public static string GetDecryptConnectionString(this ConnectionStringSettings cssc)
        {
            string encryptedConnectionString = cssc.ConnectionString;
            string decryptedConnectionString = SecureString.Decrypt(encryptedConnectionString);

            return decryptedConnectionString;
        }
    }
}