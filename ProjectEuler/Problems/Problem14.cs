using System;

namespace ProjectEuler.Problems
{
    internal class Problem14 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int longestChainNumber = 1, longestChainAmount = 1;

            for (int i = 1; i < 1000000; i++)
            {
                long num = i;
                int chainLength = 1;

                // Keep up the Collatz sequence until we get the number one
                while (num != 1)
                {
                    if (num % 2 == 0)
                        num = num / 2;
                    else
                        num = 3 * num + 1;

                    chainLength++;
                }

                if (chainLength> longestChainAmount)
                {
                    longestChainAmount = chainLength;
                    longestChainNumber = i;
                }
            }

            Console.WriteLine("Problem 14: " + longestChainNumber);
        }
    }
}
