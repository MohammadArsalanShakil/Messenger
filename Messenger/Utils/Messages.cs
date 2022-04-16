using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Utils
{
    public static class Messages
    {
        public static string encryptionErrorTitle = "Text Encryption Error";
        public static string decryptionErrorTitle = "Text Decryption Error";
        public static string hashingErrorTitle = "Text Hashing Error";
        public static string hashCopyErrorTitle = "Copying error";

        public static string keyEncryptErrorMessage = "Kindly enter key to be used for encryption";
        public static string keyDecryptErrorMessage = "Kindly enter key to be used for decryption";
        public static string encryptionErrorMessage = "Kindly enter text to be encrypted";
        public static string decryptionErrorMessage = "Kindly enter text to be decrypted";
        public static string hashingErrorMessage = "Kindly enter text for hash generation";
        public static string hashCopyErrorMessage = "Please generate hash before copying the value";
    }
}
