using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;

namespace MyComponents
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "encryptdecrypt" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select encryptdecrypt.svc or encryptdecrypt.svc.cs at the Solution Explorer and start debugging.
    public class encryptdecrypt : Iencryptdecrypt
    {
        // Replace these with securely generated Base64-encoded key and IV
        private readonly byte[] _key = Convert.FromBase64String("IJtieY+TCZPrR4W4MQZ5No476pV1H0HOhr4wCGnEt/c=");
        private readonly byte[] _iv = Convert.FromBase64String("vDfZ5DLVwPdCOckAHPBcTQ==");

        public string encrypt(string plainText)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = _key;
                    aes.IV = _iv;

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            using (StreamWriter writer = new StreamWriter(cryptoStream))
                            {
                                writer.Write(plainText);
                            }
                        }
                        return Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Encryption failed: {ex.Message}");
                throw;
            }
        }

        public string decrypt(string cipherText)
        {
            if (!IsBase64String(cipherText))
            {
                throw new ArgumentException("The provided cipherText is not a valid Base64 string.");
            }

            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = _key;
                    aes.IV = _iv;

                    byte[] buffer = Convert.FromBase64String(cipherText);

                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            using (StreamReader reader = new StreamReader(cryptoStream))
                            {
                                return reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Decryption failed: {ex.Message}");
                throw;
            }
        }

        private bool IsBase64String(string base64)
        {
            if (string.IsNullOrEmpty(base64))
                return false;

            // Check if the string length is a multiple of 4
            if (base64.Length % 4 != 0)
                return false;

            try
            {
                // Try converting the string from Base64
                Convert.FromBase64String(base64);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
