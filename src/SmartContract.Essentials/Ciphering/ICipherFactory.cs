namespace SmartContract.Essentials.Ciphering
{
    /// <summary>
    /// Factory for resolving cipher providers 
    /// </summary>
    public interface ICipherFactory
    {
        /// <summary>
        /// Creates a CBC provider
        /// </summary>
        ICbc CreateCbcProvider();
    }
}
