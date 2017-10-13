using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Probability.Tests
{
    [TestClass]
    public class BirthdayProblemTests
    {
        [TestMethod]
        public void BirthdayTest()
        {
            Assert.AreEqual(0.0, Math.Round(Problems.GetBirthdayProblemChance(1) * 100, 1));
            Assert.AreEqual(2.7, Math.Round(Problems.GetBirthdayProblemChance(5) * 100, 1));
            Assert.AreEqual(11.7, Math.Round(Problems.GetBirthdayProblemChance(10) * 100, 1));
            Assert.AreEqual(41.1, Math.Round(Problems.GetBirthdayProblemChance(20) * 100, 1));
            Assert.AreEqual(50.7, Math.Round(Problems.GetBirthdayProblemChance(23) * 100, 1));
            Assert.AreEqual(70.6, Math.Round(Problems.GetBirthdayProblemChance(30) * 100, 1));
            Assert.AreEqual(89.1, Math.Round(Problems.GetBirthdayProblemChance(40) * 100, 1));
            Assert.AreEqual(97.0, Math.Round(Problems.GetBirthdayProblemChance(50) * 100, 1));
            Assert.AreEqual(99.4, Math.Round(Problems.GetBirthdayProblemChance(60) * 100, 1));
            Assert.AreEqual(99.9, Math.Round(Problems.GetBirthdayProblemChance(70) * 100, 1));
            Assert.AreEqual(99.99997, Math.Round(Problems.GetBirthdayProblemChance(100) * 100, 5));
        }
    }
}