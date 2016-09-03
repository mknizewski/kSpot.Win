using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography
{
    public static class SecureString
    {
        private const int KeySize = 256;
        private const int DerivationIterations = 1024;
        private const string Password = "!QAZ2wsx";

        public static string Encrypt(string plainText)
        {
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            string encryptedString = string.Empty;

            using (var password = new Rfc2898DeriveBytes(Password, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(KeySize / 8);

                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;

                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();

                                var cipherTextBytes = saltStringBytes;

                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                encryptedString = Convert.ToBase64String(cipherTextBytes);

                                memoryStream.Close();
                                cryptoStream.Close();

                                cryptoStream.Dispose();
                                memoryStream.Dispose();
                                encryptor.Dispose();
                                symmetricKey.Dispose();
                                password.Dispose();
                            }
                        }
                    }
                }
            }

            return encryptedString;
        }

        public static string Decrypt(string cipherText)
        {
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(KeySize / 8).ToArray();
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(KeySize / 8).Take(KeySize / 8).ToArray();
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((KeySize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((KeySize / 8) * 2)).ToArray();
            string decryptedString = string.Empty;

            using (var password = new Rfc2898DeriveBytes(Password, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(KeySize / 8);

                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;

                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

                                decryptedString = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

                                memoryStream.Close();
                                cryptoStream.Close();

                                cryptoStream.Dispose();
                                memoryStream.Dispose();
                                decryptor.Dispose();
                                symmetricKey.Dispose();
                                password.Dispose();
                            }
                        }
                    }
                }
            }

            return decryptedString;
        }

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(randomBytes);
                rngCsp.Dispose();
            }

            return randomBytes;
        }
    }
}