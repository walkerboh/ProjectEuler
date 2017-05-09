using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    internal class Problem32 : BaseProblem
    {
        private HashSet<int> products = new HashSet<int>();
        private char[] digits = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        protected override void ExecuteProblem()
        {
            // Need a resultant string that uses 9 digits total
            // Only 1 * 4 digit numbers and 2 * 3 digits numbers meet this criteria
            // Try the largest and smallest of the other combinations and they will always be too small or too large


            for (int i = 1; i < 10; i++)
                for (int j = 1000; j <= 10000; j++)
                    if (CheckPandigital(i, j)) // If i, j, and the product have hit ten digits, we can stop processing this i
                        break;

            for (int i = 10; i < 100; i++)
                for (int j = 100; j <= 1000; j++)
                    if (CheckPandigital(i, j)) // If i, j, and the product have hit ten digits, we can stop processing this i
                        break;

            Console.WriteLine("Problem 32: " + products.Sum());
        }

        /// <summary>
        /// Checks if a multiplicand and multipler make a pandigital
        /// </summary>
        /// <param name="i">Multiplicand</param>
        /// <param name="j">Multiplier</param>
        /// <returns>True if we have passed 9 digits in use</returns>
        private bool CheckPandigital(int i, int j)
        {
            // If i and j have matching digits, just return
            if (i.ToString().Intersect(j.ToString()).Count() != 0)
                return false;

            int product = i * j;

            string newDigits = string.Concat(i, j, product);

            // Use conditional processing to check length first so the more costly enumeration won't be hit to check for all the digits
            if (newDigits.Length == 9 && digits.All(d => newDigits.Contains(d)))
                products.Add(product);

            // If we have gotten to large, let the loops know
            if (newDigits.Length > 9)
                return true;

            return false;
        }
    }
}
