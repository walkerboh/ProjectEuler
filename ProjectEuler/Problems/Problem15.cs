using System;
using System.Numerics;

namespace ProjectEuler.Problems
{
    internal class Problem15 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            // Note to self: start avoiding brute force, that was a terrible idea before looking up lattice paths

            // Total lattice paths can be computed by the binomial coefficient of a+b over a if going from (0,0) to (a,b)
            // So we need (a+b)! / (((a + b) - b)! * b!) Note: a and b are both 20

            BigInteger total = new BigInteger();
            BigInteger nFac = new BigInteger(1);
            BigInteger kFac = new BigInteger(1);

            // Compute the factorial of 40
            for (int i = 2; i <= 40; i++)
                nFac *= i;

            // Compute the factorial of 20 (why doesn't C# have built-ins for this stuff?)
            for (int i = 2; i <= 20; i++)
                kFac *= i;

            total = nFac / (kFac * kFac);

            Console.WriteLine("Problem 15: " + total);
        }
    }
}
