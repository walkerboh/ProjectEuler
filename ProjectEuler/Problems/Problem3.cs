using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem3 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            // Max factor is the square root of a number (I subtract 1 because the square root is even after rounding down)
            long largestPrimeFactor = Convert.ToInt64(Math.Sqrt(600851475143)) - 1;
            bool done = false;

            while (largestPrimeFactor > 3 && !done)
            {
                // Is the number even a factor?
                if (600851475143 % largestPrimeFactor != 0L)
                {
                    // Don't need to bother checking odds
                    largestPrimeFactor -= 2;
                    continue;
                }

                done = IsPrime(largestPrimeFactor);

                if (!done)
                    largestPrimeFactor -= 2;

                Console.WriteLine(largestPrimeFactor);
            }

            Console.WriteLine("Problem 3 - Success: " + done);
            Console.WriteLine("\tValue: " + largestPrimeFactor);
        }

        // Simple prime checking algorithm alla the pseudocode found on https://en.wikipedia.org/wiki/Primality_test
        private bool IsPrime(long number)
        {
            // Don't need to check over the square root as then we would be checking numbers for which we have already checked their pair
            long max = Convert.ToInt64(Math.Ceiling(Math.Sqrt(number)));

            if (number == 2 || number == 3)
                return true;

            if (number % 2 == 0 || number % 3 == 0)
                return false;

            // Only need to check numbers that are of the form 6k + 1 or 6k - 1 as stated on the wikipedia page, all others are composite.
            int n = 5;

            while (n <= max)
            {
                if ((number % n == 0) || (number % (n + 2) == 0))
                    return false;
                n += 6;
            }

            return true;
        }
    }
}
