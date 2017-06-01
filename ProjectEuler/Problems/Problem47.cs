using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem47 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            // Save factorizations in individual variables and cycle them to keep memory constant
            //  Just picked to start at 101 as an arbitrary starting point. Could have found the first number with 4 disnct primes but was too lazy
            Dictionary<int, int> factorization1 = Helper.Factorization(101);
            Dictionary<int, int> factorization2 = Helper.Factorization(102);
            Dictionary<int, int> factorization3 = Helper.Factorization(103);
            Dictionary<int, int> factorization4;

            bool found = false;

            int n = 103;

            while (!found)
            {
                // Get the newest factorization
                factorization4 = Helper.Factorization(++n);

                // Check them
                found = CompareFactorizations(4, factorization1, factorization2, factorization3, factorization4);

                // Rotate them down in the variables so the oldest leaves first
                factorization1 = factorization2;
                factorization2 = factorization3;
                factorization3 = factorization4;
            }

            Console.WriteLine("Problem 47: " + (n - 3));
        }

        /// <summary>
        /// Compares a list of factorizations for n unique factors
        /// </summary>
        /// <param name="factorizations">List of factorizations to compare</param>
        /// <param name="n">Number of unique factors to require</param>
        /// <returns>True if all are unique and have n factors, false otherwise</returns>
        private bool CompareFactorizations(int n, params Dictionary<int, int>[] factorizations)
        {
            // If they don't all have n primes, false
            if (!factorizations.All(f => f.Count == n))
                return false;

            // Get a list of all the prime factors
            List<KeyValuePair<int, int>> factors = factorizations.SelectMany(f => f.ToList()).ToList();

            // Return if the count of unique factors is the same as the count of all factors
            return factors.Count == factors.Distinct().Count();
        }
    }
}
