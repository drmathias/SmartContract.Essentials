using System.Security.Cryptography;
using System.Text;

namespace SmartContract.Essentials
{
    /// <summary>
    /// Generates URL friendly strings
    /// </summary>
    public class UrlFriendlyStringGenerator : IStringGenerator
    {
        private readonly static string _urlFriendlyCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_";

        /// <summary>
        /// Creates a random unique URL-friendly string
        /// </summary>
        /// <param name="length">Desired length of the string</param>
        /// <returns>The unique string result</returns>
        public string CreateUniqueString(int length)
        {
            byte[] data = new byte[length];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }

            StringBuilder result = new StringBuilder(length);
            foreach (byte b in data)
            {
                result.Append(_urlFriendlyCharacters[b % (_urlFriendlyCharacters.Length)]);
            }

            return result.ToString();
        }
    }
}
