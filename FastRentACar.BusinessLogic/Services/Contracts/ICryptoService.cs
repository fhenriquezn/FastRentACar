namespace FastRentACar.BusinessLogic.Services.Contracts
{
    public interface ICryptoService
    {
        /// <summary>
        /// Encript a plain text
        /// </summary>
        /// <param name="PlainText"></param>
        /// <returns></returns>
        string Encrypt(string PlainText);

        /// <summary>
        /// Decrypt ciphertext
        /// </summary>
        /// <param name="EncryptedText"></param>
        /// <returns></returns>
        string Decrypt(string EncryptedText);
    }
}
