using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace kSpot.Win.DAL.Extensions
{
    public static class ContextExtensions
    {
        public static string DecryptConnectionString(this ConnectionStringSettings cssc)
        {
            string decryptedConnectionString = string.Empty;

            using (var rsa = RSA.Create())
            {
                var connectionStringToByte = UTF8Encoding.UTF8.GetBytes(cssc.ConnectionString);
                var decryptionByte = rsa.Decrypt(connectionStringToByte, RSAEncryptionPadding.Pkcs1);

                decryptedConnectionString = UTF8Encoding.UTF8.GetString(decryptionByte);
                rsa.Dispose();
            }

            return decryptedConnectionString;
        }
    }
}
