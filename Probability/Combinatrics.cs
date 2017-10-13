using System;
using System.Linq;
using static Probability.Maths;

namespace Probability
{
    public static class Combinatrics
    {
        /// <summary>
        /// Gets a combination
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <param name="allowRepititions"></param>
        /// <returns></returns>
        public static int Combinations(int n, int r, bool allowRepetitions = false)
        {
            var rFactorialList = FactorialList(r);
            var combinations = allowRepetitions ? GetCombinationsWithRepititions() : GetCombinationsNoRepititions();
            return combinations;

            int GetCombinationsNoRepititions()
            {
                var nFactorialList = FactorialList(n).OrderBy(x => 1);
                var nMinusRFactorialList = FactorialList(n - r);
                var denominatorList = rFactorialList.Concat(nMinusRFactorialList).OrderBy(x => x);

                (var topList, var bottomList) = CancelOut(nFactorialList, denominatorList);
                var top = Factorial(topList);
                var bottom = Factorial(bottomList);

                var result = (double)top / bottom;
                return (int)result;
            }

            int GetCombinationsWithRepititions()
            {
                var rPlusNMinusOneFactorialList = FactorialList(r + n - 1).OrderBy(i => 1);
                var nMinusOneFactorialList = FactorialList(n - 1);

                var denominatorList = rFactorialList.Concat(nMinusOneFactorialList).OrderBy(i => i);
                (var topList, var bottomList) = CancelOut(rPlusNMinusOneFactorialList, denominatorList);
                var top = Factorial(topList);
                var bottom = Factorial(bottomList);

                var result = (double)top / bottom;
                return (int)result;
            }
        }

        public static int Permutations(int n, int r, bool allowRepetitions = false)
        {
            var permutations = allowRepetitions ? GetPermutationsWithRepititions() : GetPermutationsNoRepititions();
            return permutations;

            int GetPermutationsNoRepititions()
            {
                var nFactorialList = FactorialList(n).OrderBy(x => 1);
                var nMinusRFactorialList = FactorialList(n - r).OrderBy(x => 1);

                (var topList, var bottomList) = CancelOut(nFactorialList, nMinusRFactorialList);
                var top = Factorial(topList);
                var bottom = Factorial(bottomList);

                var result = (double)top / bottom;
                return (int)result;
            }

            int GetPermutationsWithRepititions()
            {
                var result = Math.Pow(n, r);
                return (int)result;
            }
        }
    }
}