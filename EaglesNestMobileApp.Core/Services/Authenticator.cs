/*****************************************************************************/
/*                               Authenticator                               */
/*     This class provide functions to hash a password and to compare two    */
/*     salted hashed passwords.                                              */
/*                                                                           */
/*****************************************************************************/
using PCLCrypto;
using System;
using System.Text;
namespace EaglesNestMobileApp.Core.Services
{
    public static class Authenticator
    {
        /* This method compares a plain password with a salted hashed        */
        /* password                                                          */
        public static bool VerifyPassword(string plainPassword,
                               string hashedPassword, string salt)
        {
            return HashPassword(plainPassword, salt) == hashedPassword;
        }

        /* This method creates a hash of a plain string password             */
        /* concatenated with a salt value                                    */
        public static string HashPassword(string password, string salt)
        {
            /* Change the string encoding of the password and salt and       */
            /* append the salt to the password                               */
            byte[] _plainPassword = Encoding.UTF8.GetBytes(password);
            byte[] _plainSalt = Encoding.UTF8.GetBytes(salt);
            byte[] _saltedPassword = AppendArray(_plainPassword, _plainSalt);

            /* Use the appropriate hashing algorithm and return the hashed   */
            /* password                                                      */
            IHashAlgorithmProvider hasher =
                WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(
                    HashAlgorithm.Sha512);
            byte[] _hashPassword = hasher.HashData(_saltedPassword);
            return Convert.ToBase64String(_hashPassword);
        }

        /* Appends two byte arrays. To be used for concatenating a plain     */
        /* password with its salt                                            */
        public static byte[] AppendArray(byte[] first, byte[] second)
        {
            byte[] appendedArray = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, appendedArray, 0, first.Length);
            Buffer.BlockCopy(second, 0, appendedArray, first.Length,
                second.Length);
            return appendedArray;
        }
    }
}