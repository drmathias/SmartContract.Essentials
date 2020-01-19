using System;

namespace SmartContract.Essentials.Ciphering
{
    /// <summary>
    /// A chained block cipher that uses a key and initialization vector
    /// </summary>
    public interface ICbc : IDisposable
    {
        /// <summary>
        /// Encrypts data using a CBC algorithm
        /// </summary>
        /// <param name="plainText">Plaintext string to encrypt</param>
        /// <returns>The encryption result</returns>
        CbcResult Encrypt(string plainText);

        /// <summary>
        /// Decrypts data using a CBC algorithm
        /// </summary>
        /// <param name="cipher">Cipher to decrypt</param>
        /// <param name="key">The secret encryption key</param>
        /// <param name="iv">The initialization vector</param>
        /// <returns>The plaintext string</returns>
        string Decrypt(byte[] cipher, byte[] key, byte[] iv);
    }
}
