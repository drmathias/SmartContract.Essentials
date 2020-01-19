namespace SmartContract.Essentials.Randomness
{
    /// <summary>
    /// A generator of strings
    /// </summary>
    public interface IStringGenerator
    {
        /// <summary>
        /// Creates a random unique string
        /// </summary>
        /// <param name="length">Desired length of the string</param>
        /// <returns>The unique string result</returns>
        string CreateUniqueString(int length);
    }
}
