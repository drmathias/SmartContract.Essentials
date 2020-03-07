using SHA3.Net;
using System.Text;

namespace SmartContract.Essentials.Hashing
{
    public static class Sha3Extensions
    {
        /// <summary>
        /// Computes the hash value for the specified string
        /// </summary>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ObjectDisposedException"></exception>
        public static byte[] ComputeHash(this Sha3 hasher, string value)
        {
            return hasher.ComputeHash(Encoding.UTF8.GetBytes(value));
        }
    }
}
