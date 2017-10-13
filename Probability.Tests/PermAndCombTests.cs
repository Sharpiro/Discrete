using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Probability.Tests
{
    // n = number of items possible
    // r = number of items selected
    [TestClass]
    public class PermAndCombTests
    {
        [TestMethod]
        public void NoRepetitionCombinationsTest()
        {
            Assert.AreEqual(210, Combinatrics.Combinations(n: 10, r: 4, allowRepetitions: false));
            Assert.AreEqual(253, Combinatrics.Combinations(n: 23, r: 2, allowRepetitions: false));
            Assert.AreEqual(31824, Combinatrics.Combinations(n: 18, r: 7, allowRepetitions: false));
            Assert.AreEqual(575757, Combinatrics.Combinations(n: 39, r: 5, allowRepetitions: false));
        }

        [TestMethod]
        public void RepetitionCombinationsTest()
        {
            Assert.AreEqual(715, Combinatrics.Combinations(n: 10, r: 4, allowRepetitions: true));
            Assert.AreEqual(276, Combinatrics.Combinations(n: 23, r: 2, allowRepetitions: true));
            Assert.AreEqual(346104, Combinatrics.Combinations(n: 18, r: 7, allowRepetitions: true));
            Assert.AreEqual(962598, Combinatrics.Combinations(n: 39, r: 5, allowRepetitions: true));
        }

        [TestMethod]
        public void NoRepetitionPermutationsTest()
        {
            Assert.AreEqual(5040, Combinatrics.Permutations(n: 10, r: 4, allowRepetitions: false));
            Assert.AreEqual(506, Combinatrics.Permutations(n: 23, r: 2, allowRepetitions: false));
            Assert.AreEqual(160392960, Combinatrics.Permutations(n: 18, r: 7, allowRepetitions: false));
            Assert.AreEqual(69090840, Combinatrics.Permutations(n: 39, r: 5, allowRepetitions: false));
        }

        [TestMethod]
        public void RepetitionPermutationsTest()
        {
            Assert.AreEqual(10000, Combinatrics.Permutations(n: 10, r: 4, allowRepetitions: true));
            Assert.AreEqual(529, Combinatrics.Permutations(n: 23, r: 2, allowRepetitions: true));
            Assert.AreEqual(612220032, Combinatrics.Permutations(n: 18, r: 7, allowRepetitions: true));
            Assert.AreEqual(90224199, Combinatrics.Permutations(n: 39, r: 5, allowRepetitions: true));
        }
    }
}