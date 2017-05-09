using System;

namespace ProjectEuler.Problems
{
    internal class Problem27 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            // Note: I thought brute forcing this problem was going to be a terrible idea, it'll take forever, never finish, but let's at least see what happens
            // To my surprise, it ran in ~0.3 seconds

            int bestA = 0, bestB = 0, maxLength = 0;

            // Check each possible combination of a and b (some 2000^2 possibilities)
            for (int a = -999; a < 1000; a++)
            {
                for (int b = -999; b < 1000; b++)
                {
                    int n = 0;

                    // Starting with an n of 0, check if we get a prime, if so, incremement n and keep going
                    while (Helper.IsPrime(((long)Math.Pow(n, 2) + a * n + b)))
                    {
                        n++;
                    }

                    // If we got a better length, save it
                    if (n > maxLength)
                    {
                        maxLength = n;
                        bestA = a;
                        bestB = b;
                    }
                }
            }

            Console.WriteLine("Problem 27: " + bestA * bestB);
        }
    }
}
