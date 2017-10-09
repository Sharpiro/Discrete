using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static Discrete.Bit;

namespace Discrete.Tests
{
    [TestClass]
    public class LogicGatesTests
    {
        private readonly (Bit x, Bit y)[] _cases = new[]
        {
            (Off, Off),
            (Off, On),
            (On, Off),
            (On, On)
        };

        [TestMethod]
        public void AndGateTest()
        {
            Assert.AreEqual(Off, Off & Off);
            Assert.AreEqual(Off, Off & On);
            Assert.AreEqual(Off, On & Off);
            Assert.AreEqual(On, On & On);
        }

        [TestMethod]
        public void OrGateTest()
        {
            Assert.AreEqual(Off, Off | Off);
            Assert.AreEqual(On, Off | On);
            Assert.AreEqual(On, On | Off);
            Assert.AreEqual(On, On | On);
        }

        [TestMethod]
        public void NandGateTest()
        {
            Assert.AreEqual(On, Off.Nand(Off));
            Assert.AreEqual(On, On.Nand(Off));
            Assert.AreEqual(On, Off.Nand(On));
            Assert.AreEqual(Off, On.Nand(On));
        }

        [TestMethod]
        public void NorGateTest()
        {
            Assert.AreEqual(On, Off.Nor(Off));
            Assert.AreEqual(Off, On.Nor(Off));
            Assert.AreEqual(Off, Off.Nor(On));
            Assert.AreEqual(Off, On.Nor(On));
        }

        [TestMethod]
        public void XorGateTest()
        {
            Assert.AreEqual(Off, Off.Xor(Off));
            Assert.AreEqual(On, On.Xor(Off));
            Assert.AreEqual(On, Off.Xor(On));
            Assert.AreEqual(Off, On.Xor(On));
        }

        [TestMethod]
        public void XnorGateTest()
        {
            Assert.AreEqual(On, Off.Xnor(Off));
            Assert.AreEqual(Off, On.Xnor(Off));
            Assert.AreEqual(Off, Off.Xnor(On));
            Assert.AreEqual(On, On.Xnor(On));
        }

        [TestMethod]
        public void HalfAddTest()
        {
            var result = Off.HalfAdd(Off);
            Assert.AreEqual(Off, result.Sum);
            Assert.AreEqual(Off, result.Carry);

            result = On.HalfAdd(Off);
            Assert.AreEqual(On, result.Sum);
            Assert.AreEqual(Off, result.Carry);

            result = Off.HalfAdd(On);
            Assert.AreEqual(On, result.Sum);
            Assert.AreEqual(Off, result.Carry);

            result = On.HalfAdd(On);
            Assert.AreEqual(Off, result.Sum);
            Assert.AreEqual(On, result.Carry);
        }

        [TestMethod]
        public void FullAddTest()
        {
            var result = Off.FullAdd(Off, Off);
            Assert.AreEqual(Off, result.Sum);
            Assert.AreEqual(Off, result.Carry);

            result = Off.FullAdd(Off, On);
            Assert.AreEqual(On, result.Sum);
            Assert.AreEqual(Off, result.Carry);


            //ha1 = 0 HA 0 = Sum = 0, Carry = 0
            //ha2 = 0 HA 1 = Sum = 1, Carry = 0
            // Carry = OFF
            // SUM = ON

            //result = Off.FullAdd(On);
            //Assert.AreEqual(On, result.Sum);
            //Assert.AreEqual(Off, result.Carry);

            //result = On.FullAdd(On);
            //Assert.AreEqual(Off, result.Sum);
            //Assert.AreEqual(On, result.Carry);
        }

        [TestMethod]
        public void AdditionTest()
        {
            var totalBytes = sizeof(byte);
            var totalBits = totalBytes * 8;
            var maxValue = Math.Pow(2, totalBits);

            var index = 0;
            for (var i = 0; i < maxValue; i++)
            {
                for (var j = 0; j < maxValue; j++)
                {
                    var actualSum = i + j;

                    var iBits = ((byte)i).GetBits();
                    var jBits = ((byte)j).GetBits();

                    var sumBits = FourBitAdd(iBits, jBits);
                    var temp = string.Join(string.Empty, sumBits);
                    var @decimal = Convert.ToInt32(temp, 2);

                    Assert.AreEqual(actualSum, @decimal);
                    index++;
                }
            }
            Assert.AreEqual(maxValue * maxValue, index);
        }
    }
}