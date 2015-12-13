using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem30 : BaseProblem
    {

        protected override void ExecuteProblem()
        {
            // Need an upper bound for brute force since none is given. Maximum value is x*9^5 where x also gives us an x-digit number. So we easily find that x=6 gives us 6 digits at 354294
            // making 354294 our upper bound

            double sum = 0;

            for (double i = 2; i <= 354294; i++)
            {
                // Get the digits
                char[] digits = Convert.ToString(i).ToCharArray();

                double expSum = 0;

                // Raise the digits to a power of 5 and sum
                foreach (char digit in digits)
                {
                    expSum += Math.Pow(double.Parse(digit.ToString()), 5);
                }

                // If the sum is the original number, add to the final sum
                if (i == expSum)
                    sum += expSum;
            }

            Console.WriteLine("Problem 30: " + sum);
        }

    }
}
