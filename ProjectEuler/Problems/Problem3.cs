using System;

namespace ProjectEuler.Problems
{
    internal class Problem3 : BaseProblem
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

                done = Helper.IsPrime(largestPrimeFactor);

                if (!done)
                    largestPrimeFactor -= 2;

                Console.WriteLine(largestPrimeFactor);
            }

            Console.WriteLine("Problem 3 - Success: " + done);
            Console.WriteLine("\tValue: " + largestPrimeFactor);
        }
    }
}
