using System;

namespace ProjectEuler.Problems
{
    internal class Problem10 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            long sum = 0;
            int num = 2;

            // Another brute force. Quick check if the number is prime and add it to the sum, stop at 2 million.
            while (num < 2000000)
            {
                if (Helper.IsPrime(num))
                    sum += num;

                num++;
            }

            Console.WriteLine("Problem 10: " + sum);
        }
    }
}
