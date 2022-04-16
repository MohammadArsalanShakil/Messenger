using System;
using System.Text;
using System.Security.Cryptography;

namespace Messenger.Utils
{
    /// <summary>
    /// Algorithms supported
    /// </summary>
    public enum Algorithm
    {
        MD5, SHA1, SHA256, SHA384, SHA512
    }

    public sealed class CryptoUtil
    {
        /// <summary>
        /// Your secret key
        /// WARNING: It's not a good idea change the secret key in production mode!
        /// </summary>
        public static string key = "YOUR_SECRET_KEY_GOES_HERE";

        private static TripleDES tripleDES = new TripleDESCryptoServiceProvider();
        private static MD5 md5 = new MD5CryptoServiceProvider();
        private static SHA1 sha1 = new SHA1Managed();
        private static SHA256 sha256 = new SHA256Managed();
        private static SHA384 sha384 = new SHA384Managed();
        private static SHA512 sha512 = new SHA512Managed();
        private static UTF8Encoding utf8 = new UTF8Encoding();
        private static ICryptoTransform cryptoTransform = null;
        private static StringBuilder stringBuilder = null;
        private static byte[] arrResult = null;
        private static byte[] arrBytes = null;
        private static byte[] arrKey = null;

        /// <summary>
        /// Encrypts the informed string using a secret key
        /// </summary>
        /// <param name="str">The string that will be encrypted</param>
        /// <returns>The encrypted string</returns>
        public static string Encrypt(string str)
        {
            try
            {
                arrResult = new byte[0];
                arrKey = md5.ComputeHash(utf8.GetBytes(key));

                tripleDES.Key = arrKey;
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;

                arrBytes = utf8.GetBytes(str);
                cryptoTransform = tripleDES.CreateEncryptor();
                arrResult = cryptoTransform.TransformFinalBlock(arrBytes, 0, arrBytes.Length);

                return Convert.ToBase64String(arrResult);
            }
            catch (Exception e)
            {
                return "Error while encrypting: " + e.Message;
            }
        }

        /// <summary>
        /// Decrypts the informed string
        /// </summary>
        /// <param name="str">The string that will be decrypted</param>
        /// <returns>The decrypted string</returns>
        public static string Decrypt(string str)
        {
            try
            {
                arrResult = new byte[0];
                arrKey = md5.ComputeHash(utf8.GetBytes(key));

                tripleDES.Key = arrKey;
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;

                arrBytes = Convert.FromBase64String(str);
                cryptoTransform = tripleDES.CreateDecryptor();
                arrResult = cryptoTransform.TransformFinalBlock(arrBytes, 0, arrBytes.Length);

                return utf8.GetString(arrResult);
            }
            catch (Exception e)
            {
                return "Error while decrypting: " + e.Message;
            }
        }

        /// <summary>
        /// Encrypts the informed string using a specific algorithm
        /// </summary>
        /// <param name="str">The string that will be encrypted</param>
        /// <param name="algorithm">The algorithm that will be used</param>
        /// <returns>The encrypted string</returns>
        public static string GetHashFromString(string str, Algorithm algorithm)
        {
            try
            {
                stringBuilder = new StringBuilder();

                switch (algorithm)
                {
                    case Algorithm.MD5:
                        arrBytes = md5.ComputeHash(utf8.GetBytes(str));
                        break;
                    case Algorithm.SHA1:
                        arrBytes = sha1.ComputeHash(utf8.GetBytes(str));
                        break;
                    case Algorithm.SHA256:
                        arrBytes = sha256.ComputeHash(utf8.GetBytes(str));
                        break;
                    case Algorithm.SHA384:
                        arrBytes = sha384.ComputeHash(utf8.GetBytes(str));
                        break;
                    case Algorithm.SHA512:
                        arrBytes = sha512.ComputeHash(utf8.GetBytes(str));
                        break;
                    default: // MD5
                        arrBytes = md5.ComputeHash(utf8.GetBytes(str));
                        break;
                }

                foreach (byte x in arrBytes)
                    stringBuilder.Append(x.ToString("x2"));

                return stringBuilder.ToString();
            }
            catch (Exception e)
            {
                return "Error while encrypting: " + e.Message;
            }
        }
    }
}
