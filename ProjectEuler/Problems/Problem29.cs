using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    internal class Problem29 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            List<BigInteger> values = new List<BigInteger>();

            // Simple enough, just build a list of all possible combinations
            for (int i = 2; i <= 100; i++)
            {
                for (int j = 2; j <= 100; j++)
                {
                    values.Add(BigInteger.Pow(i, j));
                }
            }

            // Get the distinct values
            values = values.Distinct().ToList();

            Console.WriteLine("Problem 29: " + values.Count);
        }
    }
}
