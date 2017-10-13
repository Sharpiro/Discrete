using System;
using System.Collections.Generic;
using System.Linq;

namespace Discrete
{
    public static class Maths
    {
        private const int DaysPerYear = 365;

        public static double GetBirthdayProblemChanceCombinations(int n)
        {
            const double chanceDiffPerPerson = 1 - (double)1 / DaysPerYear;
            var combinations = Combinations(n, 2);
            var chanceDiffForAllN = Math.Pow(chanceDiffPerPerson, combinations);
            var chance2PplHaveSameBDay = 1 - chanceDiffForAllN;
            return chance2PplHaveSameBDay;
        }

        public static double GetBirthdayProblemChance(int n)
        {

            double sum = 1;
            for (var i = 1; i <= (n - 1); i++)
                sum *= 1 - (double)i / DaysPerYear;
            return 1 - sum;
        }

        /// <summary>
        /// Gets a combination
        /// </summary>
        public static int Combinations(int n, int r)
        {
            var nFactorialList = FactorialList(n).OrderBy(x => 1);
            var rFactorialList = FactorialList(r);
            var nMinusRFactorialList = FactorialList(n - r);
            var bottomListCombined = rFactorialList.Concat(nMinusRFactorialList).OrderBy(x => x);

            (var topList, var bottomList) = CancelOut(nFactorialList, bottomListCombined);
            var top = Factorial(topList);
            var bottom = Factorial(bottomList);

            var result = (double)top / bottom;
            return (int)result;
        }

        public static long Factorial(int n)
        {
            checked
            {
                var factorialList = FactorialList(n);
                return Factorial(factorialList);
            }
        }

        public static int Factorial(IEnumerable<int> nItems)
        {
            checked
            {
                var sum = 1;
                foreach (var i in nItems) sum *= i;
                return sum;
            }
        }

        public static IEnumerable<int> FactorialList(int n) => Enumerable.Range(1, n);

        /// <summary>
        /// cancels out all items that exist in both lists
        /// </summary>
        public static (IOrderedEnumerable<int> ListA, IOrderedEnumerable<int> ListB) CancelOut(IOrderedEnumerable<int> enumerableA, IOrderedEnumerable<int> enumerableB)
        {
            var arrayA = enumerableA.ToArray();
            var arrayB = enumerableB.ToArray();
            for (var i = 0; i < arrayA.Length; i++)
            {
                for (var j = i; j < arrayB.Length; j++)
                {
                    var topItem = arrayA[i];
                    var bottomItem = arrayB[j];

                    if (bottomItem < topItem) continue;
                    else if (bottomItem > topItem) break;
                    arrayA[i] = -1;
                    arrayB[j] = -1;
                    break;
                }
            }
            return (arrayA.Where(x => x != -1).OrderBy(x => 1), arrayB.Where(x => x != -1).OrderBy(x => 1));
        }
    }
}