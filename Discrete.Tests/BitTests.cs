using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Discrete.Tests
{
    [TestClass]
    public class BitTests
    {
        [TestMethod]
        public void ByteToBitsTest()
        {
            const int numberOfBytes = sizeof(byte);
            var max = Math.Pow(2, numberOfBytes * 8);
            for (ushort i = 0; i < max; i++)
            {
                var bits = ((byte)i).GetBits();
                var bitsString = string.Join(string.Empty, bits.Select(b => b.ToString()));
                var @decimal = Convert.ToInt32(bitsString, 2);
                Assert.AreEqual(i, @decimal);
            }
        }
    }
}