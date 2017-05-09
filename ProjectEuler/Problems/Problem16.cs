using System;
using System.Numerics;

namespace ProjectEuler.Problems
{
    internal class Problem16 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            BigInteger product = new BigInteger(1);

            // Calculate 2^1000
            for (int i = 0; i < 1000; i++)
                product *= 2;

            // Get all the digits
            char[] digits = product.ToString().ToCharArray();

            long sum = 0;

            // Convert each digit to a numeric and sum
            foreach (char digit in digits)
            {
                sum += long.Parse(digit.ToString());
            }

            Console.WriteLine("Problem 16: " + sum);
        }
    }
}
