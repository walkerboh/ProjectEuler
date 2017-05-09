using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    internal class Problem24 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            // Get the permutations
            List<string> permutations = Helper.GetPermutations("", "0123456789").ToList();

            // Sort the list
            permutations.Sort();

            // Get the one millionth one (index 999,999)
            Console.WriteLine("Problem 24: " + permutations[999999]);
        }
    }
}
