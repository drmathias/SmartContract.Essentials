using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace SmartContract.Essentials.Tests
{
    public class UrlFriendlyStringGeneratorTests
    {
        [Test]
        public void CreateUniqueString_SmallSample_NoDuplicates()
        {
            var strings = new List<string>();
            for (int i = 0; i < 100000; i++)
            {
                strings.Add(new UrlFriendlyStringGenerator().CreateUniqueString(15));
            }

            var distinctStrings = strings.Distinct().ToList();
            Assert.That(distinctStrings.Count, Is.EqualTo(100000));
        }
    }
}
