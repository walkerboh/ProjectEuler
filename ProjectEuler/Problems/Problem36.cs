using System;

namespace ProjectEuler.Problems
{
    internal class Problem36 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int sum = 0;

            for (int i = 1; i <= 1000000; i++)
            {
                string base2 = Convert.ToString(i, 2).TrimStart(new[] { '0' });

                if (Helper.IsPalindrome(i) && Helper.IsPalindrome(base2))
                    sum += i;
            }

            Console.WriteLine("Problem 36: " + sum);
        }
    }
}
