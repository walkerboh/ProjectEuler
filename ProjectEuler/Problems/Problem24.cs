using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem24 : BaseProblem
    {
        List<string> permutations = new List<string>();

        protected override void ExecuteProblem()
        {
            // Get the permutations
            GetPermutations("", "0123456789");

            // Sort the list
            permutations.Sort();

            // Get the one millionth one (index 999,999)
            Console.WriteLine("Problem 24: " + permutations[999999]);
        }

        // Basic permutation. fixedChar are the characters already permuted and chars are the available ones
        private void GetPermutations(string fixedChar, string chars)
        {
            // If only one character left, just take it on the end
            if (chars.Length == 1)
                permutations.Add(fixedChar + chars);

            // Loop through all the available characters and find all the permutations with the remaining characters
            for (int i = 0; i < chars.Length; i++)
                GetPermutations(fixedChar + chars[i], chars.Substring(0, i) + chars.Substring(i + 1, chars.Length - (i + 1)));
        }
    }
}
