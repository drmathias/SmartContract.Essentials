using System;
using System.IO;
using System.Security.Cryptography;

namespace SmartContract.Essentials.Ciphering
{
    /// <summary>
    /// A implementation of AES that produces minimal length output, while still being secure
    /// </summary>
    public class AesCbc : ICbc
    {
        private readonly Aes _provider;

        /// <summary>
        /// Creates an AES provider that can be used for encryption or decryption
        /// </summary>
        public AesCbc()
        {
            _provider = Aes.Create();
            _provider.Mode = CipherMode.CBC;
            _provider.Padding = PaddingMode.PKCS7;
        }

        /// <summary>
        /// Encrypts data using a CBC algorithm
        /// </summary>
        /// <param name="plainText">Plaintext string to encrypt</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>The encryption result</returns>
        public CbcResult Encrypt(string plainText)
        {
            if (plainText is null)
                throw new ArgumentNullException(nameof(plainText));
            if (plainText.Length <= 0)
                throw new ArgumentException("Plaintext must have a value", nameof(plainText));

            using (var encryptor = _provider.CreateEncryptor())
            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                using (var streamWriter = new StreamWriter(cryptoStream))
                {
                    streamWriter.Write(plainText);
                }

                var cipher = memoryStream.ToArray();
                return new CbcResult(cipher, _provider.Key, _provider.IV);
            }
        }

        /// <summary>
        /// Decrypts data using a CBC algorithm
        /// </summary>
        /// <param name="cipher">Cipher to decrypt</param>
        /// <param name="key">The secret encryption key</param>
        /// <param name="iv">The initialization vector</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>The plaintext string</returns>
        public string Decrypt(byte[] cipher, byte[] key, byte[] iv)
        {
            if (cipher is null)
                throw new ArgumentNullException(nameof(cipher));
            if (key is null)
                throw new ArgumentNullException(nameof(key));
            if (iv is null)
                throw new ArgumentNullException(nameof(iv));
            if (cipher.Length % 16 != 0)
                throw new ArgumentException("Ciphertext must be in blocks of 16 bytes", nameof(cipher));
            if (key.Length != 32)
                throw new ArgumentException("Key must be 32 bytes", nameof(key));
            if (iv.Length != 16)
                throw new ArgumentException("IV must be 16 bytes", nameof(iv));

            using (var decryptor = _provider.CreateDecryptor(key, iv))
            using (var memoryStream = new MemoryStream(cipher))
            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
            using (var streamReader = new StreamReader(cryptoStream))
            {
                return streamReader.ReadToEnd();
            }
        }

        public void Dispose()
        {
            _provider.Dispose();
        }
    }
}
