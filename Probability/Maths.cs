using System;
using System.Collections.Generic;
using System.Linq;

namespace Probability
{
    public static class Maths
    {
        public static ulong Factorial(int n)
        {
            var factorialList = FactorialList(n);
            return Factorial(factorialList);
        }

        public static ulong Factorial(IEnumerable<int> nItems)
        {
            ulong sum = 1;
            foreach (uint i in nItems) sum *= i;
            return sum;
        }

        public static IEnumerable<int> FactorialList(int n) => Enumerable.Range(1, n);

        /// <summary>
        /// cancels out all items that exist in both lists
        /// </summary>
        /// <param name="enumerableA"></param>
        /// <param name="enumerableB"></param>
        /// <returns>2 new lists without the items that exist in both lists</returns>
        public static (IOrderedEnumerable<T> EnumerableA, IOrderedEnumerable<T> EnumerableB) CancelOut<T>(IOrderedEnumerable<T> enumerableA, IOrderedEnumerable<T> enumerableB) where T : IComparable
        {
            var arrayA = enumerableA.Select(i => (Data: i, ShouldDelete: false)).ToArray();
            var arrayB = enumerableB.Select(i => (Data: i, ShouldDelete: false)).ToArray();
            for (var i = 0; i < arrayA.Length; i++)
            {
                for (var j = i; j < arrayB.Length; j++)
                {
                    var topItem = arrayA[i];
                    var bottomItem = arrayB[j];

                    if (bottomItem.Data.CompareTo(topItem.Data) < 0) continue;
                    else if (bottomItem.Data.CompareTo(topItem.Data) > 0) break;
                    arrayA[i].ShouldDelete = true;
                    arrayB[j].ShouldDelete = true;
                    break;
                }
            }
            return (arrayA.Where(x => !x.ShouldDelete).Select(x => x.Data).OrderBy(x => 1), arrayB.Where(x => !x.ShouldDelete).Select(x => x.Data).OrderBy(x => 1));
        }
    }
}