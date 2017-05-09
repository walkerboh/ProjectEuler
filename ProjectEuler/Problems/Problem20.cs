using System;
using System.Numerics;

namespace ProjectEuler.Problems
{
    internal class Problem20 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            BigInteger factorial = new BigInteger(1);

            // Compute 100!
            for (int i = 2; i <= 100; i++)
                factorial *= i;

            // Split the number into chars
            char[] digitChars = factorial.ToString().ToCharArray();

            long sum = 0;

            // Convert digits back to numerics and sum
            foreach (char digitChar in digitChars)
                sum += long.Parse(Convert.ToString(digitChar));

            Console.WriteLine("Problem 20: " + sum);
        }
    }
}
