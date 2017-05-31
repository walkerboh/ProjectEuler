using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    internal class Problem46 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int i = 9;

            while (true)
            {
                // If not prime, try the next odd number
                if (Helper.IsPrime(i))
                {
                    i += 2;
                    continue;
                }

                bool found = false;

                // Loop through all the primes smaller than the current number
                foreach (int s in Helper.ESieve(i))
                {
                    int p = 1;

                    // Loop through all the possible squares
                    while (s + 2 * p * p < i)
                    {
                        p++;
                    }

                    // If we found the number this isn't our answer so mark it found and break out of the foreach
                    if (s + 2 * p * p == i)
                        found = true;

                    if (found)
                        break;
                }

                // If we didn't find a solution, this is the answer
                if (!found)
                {
                    Console.WriteLine("Problem 46: " + i);
                    return;
                }

                i += 2;
            }
        }
    }
}
