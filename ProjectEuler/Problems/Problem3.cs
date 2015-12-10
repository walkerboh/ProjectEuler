using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem3 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            long largestPrimeFactor = Convert.ToInt64(Math.Sqrt(600851475143)) + 1;
            bool done = false;

            while (largestPrimeFactor > 3 && !done)
            {
                if (600851475143 % largestPrimeFactor != 0l)
                {
                    largestPrimeFactor -= 2;
                    continue;
                }

                done = IsPrime(largestPrimeFactor);
                if (!done)
                    largestPrimeFactor -= 2;

                Console.WriteLine(largestPrimeFactor);
            }

            Console.WriteLine("Problem 3 - Success: " + done);
            Console.WriteLine("\tValue: " + largestPrimeFactor);
        }

        private bool IsPrime(long number)
        {
            long max = Convert.ToInt64(Math.Ceiling(Math.Sqrt(number)));

            if (number == 2 || number == 3)
                return true;

            if (number % 2 == 0 || number % 3 == 0)
                return false;

            int n = 5;

            while (n <= max)
            {
                if ((number % n == 0) || (number % (n + 2) == 0))
                    return false;
                n += 6;
            }

            return true;
        }
    }
}
