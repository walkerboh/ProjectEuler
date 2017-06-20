using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem53 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int count = 0;

            // Brute force, very simple
            for (int num = 1; num <= 100; num++)
                for (int i = 1; i <= num; i++)
                    if (Combinations(num, i) > 1000000)
                        count++;

            Console.WriteLine("Problem 53: " + count);
        }

        private BigInteger Combinations(int n, int r)
        {
            return (n.Fac()) / (r.Fac() * (n - r).Fac());
        }
    }
}
