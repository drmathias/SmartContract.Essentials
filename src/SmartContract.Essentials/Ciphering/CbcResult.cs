namespace SmartContract.Essentials.Ciphering
{
    /// <summary>
    /// Cipher result containing all the values that are needed for deciphering
    /// </summary>
    public class CbcResult
    {
        /// <summary>
        /// Creates a CBC result
        /// </summary>
        /// <param name="cipher">The enciphered value</param>
        /// <param name="key">Key used for enciphering</param>
        /// <param name="iv">Initialization vector used for enciphering</param>
        internal CbcResult(byte[] cipher, byte[] key, byte[] iv)
        {
            Cipher = cipher;
            Key = key;
            IV = iv;
        }

        /// <summary>
        /// The enciphered value
        /// </summary>
        public byte[] Cipher { get; }

        /// <summary>
        /// Key used for enciphering
        /// </summary>
        public byte[] Key { get; }

        /// <summary>
        /// Initialization vector used for enciphering
        /// </summary>
        public byte[] IV { get; }
    }
}
