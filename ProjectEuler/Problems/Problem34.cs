using System;

namespace ProjectEuler.Problems
{
    internal class Problem34 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            // To find an upper bound, we do a similar strategy to problem 30, 9!*7 is 7 digits, 9!*8 is also 7, so stop at *7

            int result = 0;

            // Precalculate the factorials since we will only ever need 9 of them;
            int[] facts = new int[10];
            for (int i = 0; i < 10; i++)
                facts[i] = i.Fac();

            for (int i = 3; i < 2540161; i++)
            {
                int sumOfFacts = 0;
                int num = i;

                // Use this trick to just pull of digits
                // Don't want a useless string conversion here
                while (num > 0)
                {
                    sumOfFacts += facts[num % 10];
                    num /= 10;
                }

                if (sumOfFacts == i)
                    result += i;
            }

            Console.WriteLine("Problem 34: " + result);
        }
    }
}
