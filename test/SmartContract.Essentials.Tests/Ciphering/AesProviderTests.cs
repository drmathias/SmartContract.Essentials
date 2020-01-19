using NUnit.Framework;
using SmartContract.Essentials.Ciphering;
using System;

namespace SmartContract.Essentials.Tests.Ciphering
{
    public class AesProviderTests
    {
        [Test]
        public void Encrypt_NullPlainText_ThrowsArgumentNullException()
        {
            using var provider = new AesCbc();
            Assert.That(() => provider.Encrypt(null as string), Throws.ArgumentNullException);
        }

        [Test]
        public void Encrypt_EmptyPlainText_ThrowsArgumentException()
        {
            using var provider = new AesCbc();
            Assert.That(() => provider.Encrypt(string.Empty), Throws.ArgumentException);
        }

        [TestCase("Fifteen chars..", ExpectedResult = 16)]
        [TestCase("Sixteen chars...", ExpectedResult = 32)]
        [TestCase("Thirty one characters long.....", ExpectedResult = 32)]
        [TestCase("Thirty two characters long......", ExpectedResult = 48)]
        public int Encrypt_CharacterLength_CipherIsExpectedNumberOfBytes(string plainText)
        {
            using var provider = new AesCbc();
            var encryptionResult = provider.Encrypt(plainText);
            return encryptionResult.Cipher.Length;
        }

        [Test]
        public void Decrypt_NullCipher_ThrowsArgumentNullException()
        {
            CbcResult encryptionResult;
            using (var provider1 = new AesCbc())
            {
                encryptionResult = provider1.Encrypt("Hello world");
            }

            using var provider2 = new AesCbc();
            Assert.That(() => provider2.Decrypt(null, encryptionResult.Key, encryptionResult.IV), Throws.ArgumentNullException);
        }

        [Test]
        public void Decrypt_CipherLengthNotDivisibleBy16_ThrowsArgumentException()
        {
            CbcResult encryptionResult;
            using (var provider1 = new AesCbc())
            {
                encryptionResult = provider1.Encrypt("Hello world");
            }

            using var provider2 = new AesCbc();
            Assert.That(() => provider2.Decrypt(new byte[new Random().Next(1, 16)], encryptionResult.Key, encryptionResult.IV), Throws.ArgumentException);
        }

        [Test]
        public void Decrypt_NullKey_ThrowsArgumentNullException()
        {
            CbcResult encryptionResult;
            using (var provider1 = new AesCbc())
            {
                encryptionResult = provider1.Encrypt("Hello world");
            }

            using var provider2 = new AesCbc();
            Assert.That(() => provider2.Decrypt(encryptionResult.Cipher, null, encryptionResult.IV), Throws.ArgumentNullException);
        }

        [Test]
        public void Decrypt_KeyIsNot32Bytes_ThrowsArgumentException()
        {
            CbcResult encryptionResult;
            using (var provider1 = new AesCbc())
            {
                encryptionResult = provider1.Encrypt("Hello world");
            }

            using var provider2 = new AesCbc();
            Assert.That(() => provider2.Decrypt(encryptionResult.Cipher, new byte[16], encryptionResult.IV), Throws.ArgumentException);
        }

        [Test]
        public void Decrypt_NullIV_ThrowsArgumentNullException()
        {
            CbcResult encryptionResult;
            using (var provider1 = new AesCbc())
            {
                encryptionResult = provider1.Encrypt("Hello world");
            }

            using var provider2 = new AesCbc();
            Assert.That(() => provider2.Decrypt(encryptionResult.Cipher, encryptionResult.Key, null), Throws.ArgumentNullException);
        }

        [Test]
        public void Decrypt_IVIsNot16Bytes_ThrowsArgumentException()
        {
            CbcResult encryptionResult;
            using (var provider1 = new AesCbc())
            {
                encryptionResult = provider1.Encrypt("Hello world");
            }

            using var provider2 = new AesCbc();
            Assert.That(() => provider2.Decrypt(encryptionResult.Cipher, encryptionResult.Key, new byte[32]), Throws.ArgumentException);
        }

        [TestCase("Hello world")]
        [TestCase("Smart contract")]
        public void Decrypt_PlainTextStringEncrypted_ResultMatchesPlaintext(string plainText)
        {
            CbcResult encryptionResult;
            using (var provider1 = new AesCbc())
            {
                encryptionResult = provider1.Encrypt(plainText);
            }

            using var provider2 = new AesCbc();
            var plainTextResult = provider2.Decrypt(encryptionResult.Cipher, encryptionResult.Key, encryptionResult.IV);
            Assert.That(plainTextResult, Is.EqualTo(plainText));
        }
    }
}
