using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Discrete.Tests.OldStack
{
    [TestClass]
    public class BirthdayProblemTests
    {
        [TestMethod]
        public void BirthdayTest()
        {
            var temp = Maths.GetBirthdayProblemChance(200) * 100;

            Assert.AreEqual(0.0, Math.Round(Maths.GetBirthdayProblemChance(1) * 100, 1));
            Assert.AreEqual(2.7, Math.Round(Maths.GetBirthdayProblemChance(5) * 100, 1));
            Assert.AreEqual(11.7, Math.Round(Maths.GetBirthdayProblemChance(10) * 100, 1));
            Assert.AreEqual(41.1, Math.Round(Maths.GetBirthdayProblemChance(20) * 100, 1));
            Assert.AreEqual(50.7, Math.Round(Maths.GetBirthdayProblemChance(23) * 100, 1));
            Assert.AreEqual(70.6, Math.Round(Maths.GetBirthdayProblemChance(30) * 100, 1));
            Assert.AreEqual(89.1, Math.Round(Maths.GetBirthdayProblemChance(40) * 100, 1));
            Assert.AreEqual(97.0, Math.Round(Maths.GetBirthdayProblemChance(50) * 100, 1));
            Assert.AreEqual(99.4, Math.Round(Maths.GetBirthdayProblemChance(60) * 100, 1));
            Assert.AreEqual(99.9, Math.Round(Maths.GetBirthdayProblemChance(70) * 100, 1));
            Assert.AreEqual(99.99997, Math.Round(Maths.GetBirthdayProblemChance(100) * 100, 5));

            //var temp = Math.Round(Maths.GetBirthdayProblemChance(200) * 100, 28);
        }
    }
}