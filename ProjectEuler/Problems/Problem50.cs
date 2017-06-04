using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem50 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int maxPrime = 0, maxLength = 0;

            // Get all primes < 500,000. THat max because at that point, any two will be over 1 million and we know the lenth is longer than that
            List<int> primes = Helper.ESieve(500000).ToList();

            for (int i = 0; i < primes.Count; i++)
            {
                int length = 1;

                int runningTotal = primes[i];

                // Loop through them all adding to the running total
                for (int j = i + 1; j < primes.Count; j++)
                {
                    runningTotal += primes[j];

                    // If we go over 1 million, jump to the next starting prime
                    if (runningTotal > 1000000)
                        break;

                    length++;

                    // If the number is prime, and the length is longer than our current max, store the length and prime
                    if (Helper.IsPrime(runningTotal) && length > maxLength)
                    {
                        maxPrime = runningTotal;
                        maxLength = length;
                    }
                }
            }

            Console.WriteLine("Problem 50: " + maxPrime);
        }
    }
}
