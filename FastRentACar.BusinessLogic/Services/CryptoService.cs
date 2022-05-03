using FastRentACar.BusinessLogic.Services.Contracts;
using FastRentACar.Domain.AppSettings;
using Microsoft.Extensions.Options;
using System;
using System.Security.Cryptography;
using System.Text;

namespace FastRentACar.BusinessLogic.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly RSASettings _rsaSettings;

        public CryptoService(IOptions<Settings> settings)
        {
            _rsaSettings = settings.Value.RSASettings;
        }

        public string Encrypt(string PlainText)
        {
            // Convert the text to an array of bytes   
            byte[] dataToEncrypt = Encoding.Unicode.GetBytes(PlainText);

            // Create a byte array to store the encrypted data in it   
            byte[] encryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Set the rsa pulic key   
                rsa.FromXmlString(_rsaSettings.PublicKey);

                // Encrypt the data and store it in the encyptedData Array   
                encryptedData = rsa.Encrypt(dataToEncrypt, false);
            }
            return Convert.ToBase64String(encryptedData);
        }

        public string Decrypt(string EncryptedText)
        {
            // read the encrypted bytes from the file   
            byte[] dataToDecrypt = Convert.FromBase64String(EncryptedText);

            // Create an array to store the decrypted data in it   
            byte[] decryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Set the private key of the algorithm   
                rsa.FromXmlString(_rsaSettings.PrivateKey);
                decryptedData = rsa.Decrypt(dataToDecrypt, false);
            }

            // Get the string value from the decryptedData byte array   
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            return byteConverter.GetString(decryptedData);
        }
    }
}
