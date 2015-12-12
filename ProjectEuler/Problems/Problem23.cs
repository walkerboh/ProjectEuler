using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem23 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            List<int> abundantNumbers = new List<int>();

            // Get a list of all abundant numbers less than 28123
            // Can use that as an upper limit since the problems state the sums will stop at 28123 so obviously something larger than that cannot add to smaller
            for (int i = 1; i < 28123; i++)
            {
                if (i < SumDivisors(i))
                    abundantNumbers.Add(i);
            }

            List<int> abundantSums = new List<int>();

            // Compute all the abundant sums first
            foreach (int abundantNum in abundantNumbers)
            {
                abundantNumbers.ForEach(num => abundantSums.Add(num + abundantNum));
            }

            // Sort the list, remove duplicates and remove anything larger than what the problem states we need to look for
            // (Since everything above 28123 can be expressed as a sum we don't need numbers larger than that to find ones that aren't)
            abundantSums.Sort(); // Sorting helps the execution path of the program. See: http://stackoverflow.com/questions/11227809/why-is-processing-a-sorted-array-faster-than-an-unsorted-array
            abundantSums = abundantSums.Distinct().Where(num => num <= 28500).ToList();

            int sum = 0;

            // Loop through all the possible numbers and add it to the sum if the list doesn't contain it
            for (int i = 1; i < 28124; i++)
            {
                if (!abundantSums.Contains(i))
                    sum += i;
            }

            Console.WriteLine("Problem 23: " + sum);
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

            return divisors.Distinct().Sum();
        }
    }
}
