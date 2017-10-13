using System;

namespace Probability
{
    public static class Problems
    {
        private const int DaysPerYear = 365;

        public static double GetBirthdayProblemChanceByCombinations(int n)
        {
            const double chanceDiffPerPerson = 1 - (double)1 / DaysPerYear;
            var combinations = Combinatrics.Combinations(n, 2);
            var chanceDiffForAllN = Math.Pow(chanceDiffPerPerson, combinations);
            var chance2PplHaveSameBDay = 1 - chanceDiffForAllN;
            return chance2PplHaveSameBDay;
        }

        public static double GetBirthdayProblemChance(int n)
        {
            double sum = 1;
            for (double i = 1; i <= (n - 1); i++)
                sum *= 1 - i / DaysPerYear;
            return 1 - sum;
        }

        public static double CouponCollectorProblem(int n)
        {
            throw new NotImplementedException();
        }
    }
}