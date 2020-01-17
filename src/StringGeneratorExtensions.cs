namespace SmartContract.Essentials
{
    /// <summary>
    /// Common use extensions for string generator
    /// </summary>
    public static class StringGeneratorExtensions
    {
        /// <summary>
        /// Generates a password that is optimised for AES encryption
        /// </summary>
        /// <param name="stringGenerator"></param>
        /// <returns></returns>
        public static string GeneratePassword(this IStringGenerator stringGenerator)
        {
            return stringGenerator.CreateUniqueString(15);
        }
    }
}
