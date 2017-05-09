using System;

namespace ProjectEuler.Problems
{
    internal class Problem1 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int sum = 0;

            // Simple brute force solution - Find all numbers in [1,1000] that are multiples of 3 or 5 and add to the sum.
            // Avoids the repeats of trying to sum them separately.
            for (int i = 1; i < 1000; i++)
                if ((i % 3) == 0 || (i % 5) == 0)
                    sum += i;

            Console.WriteLine("Problem 1: " + sum);
        }
    }
}
