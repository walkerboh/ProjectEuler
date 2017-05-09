using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    internal class Problem21 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            Dictionary<int, long> divisorSums = new Dictionary<int, long>();

            // Create a list of all the numbers and the sums of their divisors
            for (int i = 1; i < 10000; i++)
            {
                divisorSums.Add(i, SumDivisors(i));
            }

            long sum = 0;

            foreach (KeyValuePair<int, long> num in divisorSums)
            {
                KeyValuePair<int, long> amicableNumber;

                // If there is a match where the current numbers sum is equal to a number in the range AND that match isn't the same number as its sum (1 and 1, etc.)....
                if (divisorSums.Any(match => match.Key == num.Value && match.Key != match.Value))
                {
                    // Get that match and confirm it is a reciprocal match, if so add the number
                    // Don't add the match, can't skip in the loop so we will just find it again later (might be faster way to not find each twice but I'm lazy)
                    amicableNumber = divisorSums.Single(match => match.Key == num.Value);
                    if (amicableNumber.Value == num.Key)
                        sum += num.Key;
                }
            }

            Console.WriteLine("Problem 21: " + sum);
        }

        // Returns the sum of all divisors of input n
        private long SumDivisors(int n)
        {
            // Only need to look up to the square root of n for divisors
            // "But that only returns half of the divisors!" you must be thinking, well fret not and keep reading
            int max = Convert.ToInt32(Math.Floor(Math.Sqrt(n)));

            // Just add one to simplify things since all numbers are divisble by 1
            List<long> divisors = new List<long> { 1 };

            // Loop through all possible divisors in the first half of the possible set...
            for (int i = 2; i <= max; i++)
            {
                if (n % i == 0)
                {
                    // And when a divisor is found add it AND its reciprocal. Quicker to not have to keep looping
                    divisors.Add(i);
                    divisors.Add(n / i);
                }
            }

            return divisors.Sum();
        }
    }
}
