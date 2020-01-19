namespace SmartContract.Essentials.Ciphering
{
    /// <summary>
    /// Factory for resolving AES ciphers
    /// </summary>
    public class AesCipherFactory : ICipherFactory
    {
        /// <summary>
        /// Creates an AES CBC provider
        /// </summary>
        public ICbc CreateCbcProvider() => new AesCbc();
    }
}
