using System;

namespace ProjectEuler.Problems
{
    internal class Problem2 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int sum = 0;

            int a = 1, b = 2;

            // Iterative fibonnaci until value is over 4 million
            while (b < 4000000)
            {
                // Simple even check and add to sum
                //Add after checking over 4 million so we can be sure we haven't gone past the max
                if (b % 2 == 0)
                    sum += b;

                int temp = a + b;
                a = b;
                b = temp;
            }

            Console.WriteLine("Problem 2: " + sum);
        }
    }
}
