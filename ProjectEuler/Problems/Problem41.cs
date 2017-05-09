using System;

namespace ProjectEuler.Problems
{
    internal class Problem41 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int max = 0;

            // Not the fastest solution, but it works as a brute force
            // Working from the smallest to largest isn't probably the fastest haha

            foreach (int prime in Helper.ESieve(1000000000))
            {
                if (Helper.IsPandigital(prime.ToString(), prime.ToString().Length))
                {
                    max = prime;
                }
            }

            Console.WriteLine("Problem 41: " + max);
        }
    }
}
