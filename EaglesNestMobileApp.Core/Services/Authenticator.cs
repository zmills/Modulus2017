using PCLCrypto;
using System;
using System.Text;

namespace EaglesNestMobileApp.Core.Services
{
    public static class Authenticator
    {
        // This method compares a plain password with a salted hashed password
        public static bool VerifyPassword(string plainPassword, string hashedPassword, string salt)
        {
            return HashPassword(plainPassword, salt) == plainPassword;
        }

        // This method creates a hash of a plain string password concatenated with a salt value
        public static string HashPassword(string password, string salt)
        {
            byte[] _plainPassword = Encoding.UTF8.GetBytes(password);
            byte[] _plainSalt = Encoding.UTF8.GetBytes(salt);
            byte[] _saltedPassword = AppendArray(_plainPassword, _plainSalt);

            IHashAlgorithmProvider hasher = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha512);

            byte[] _hashPassword = hasher.HashData(_saltedPassword);
            return Convert.ToBase64String(_hashPassword);
        }

        // Appends two byte arrays. To be used for concatenating a plain password with its salt
        public static byte[] AppendArray(byte[] first, byte[] second)
        {
            byte[] appendedArray = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, appendedArray, 0, first.Length);
            Buffer.BlockCopy(second, 0, appendedArray, first.Length, second.Length);
            return appendedArray;
        }
    }
}
