using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem25 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            BigInteger a = new BigInteger(1);
            BigInteger b = new BigInteger(1);
            BigInteger temp = new BigInteger();

            // Already have 1 and 1 accounted for so start index at 2
            int index = 2;
            string fib;

            do
            {
                // Compute next term
                temp = a + b;
                a = b;
                b = temp;

                // Get the string version (easiest way to count number of digits)
                fib = b.ToString();

                // Increment index
                index++;
            } while (fib.Length < 1000); //Stop when we find the length we want

            Console.WriteLine("Problem 25: " + index);
        }
    }
}
