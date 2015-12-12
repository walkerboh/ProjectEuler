using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem26 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int maxLength = 0, maxDivsor = 0;

            // Essentially doing long division here since we are looking for the results of a divison

            // Starting at the largest divisor since those will neccessarily create the largest possible result (and thus cycle)
            for (int i = 999; i > 1; i--)
            {
                // If the current max length is larger than the current divisor, stop as stated in the comment above
                if (maxLength > i)
                    break;

                int[] remainders = new int[i];
                int value = 1;
                int length = 0;

                // While the current remainder isn't the starting value and there is still a remainder, keep doing "division"
                while (remainders[value] == 0 && value != 0)
                {
                    remainders[value] = length;
                    value *= 10;
                    value %= i;
                    length++;
                }

                // If the cycle length is longer than the maximum found length, store the new max and divisor
                if (length - remainders[value] > maxLength)
                {
                    maxLength = length - remainders[value];
                    maxDivsor = i;
                }
            }

            Console.WriteLine("Problem 26: " + maxDivsor);
        }
    }
}
