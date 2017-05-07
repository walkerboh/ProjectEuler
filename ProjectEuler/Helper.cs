using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    static class Helper
    {
        private static readonly char[] digits = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        // Helper to get an artifact file
        public static string GetArtifactFilePath(string fileName)
        {
            return Assembly.GetExecutingAssembly().Location.Replace(@"\bin\Debug\ProjectEuler.exe", @"\Artifacts\" + fileName);
        }

        // Simple prime checking algorithm alla the pseudocode found on https://en.wikipedia.org/wiki/Primality_test
        public static bool IsPrime(long number)
        {
            if (number <= 1)
                return false;

            // Don't need to check over the square root as then we would be checking numbers for which we have already checked their pair
            long max = Convert.ToInt64(Math.Ceiling(Math.Sqrt(number)));

            if (number == 2 || number == 3)
                return true;

            if (number % 2 == 0 || number % 3 == 0)
                return false;

            // Only need to check numbers that are of the form 6k + 1 or 6k - 1 as stated on the wikipedia page, all others are composite.
            int n = 5;

            while (n <= max)
            {
                if ((number % n == 0) || (number % (n + 2) == 0))
                    return false;
                n += 6;
            }

            return true;
        }

        public static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        public static int Factorial(int a)
        {
            if (a <= 1)
                return 1;

            return a * Factorial(a - 1);
        }

        // Because why not
        public static int Fac(this int a)
        {
            return Factorial(a);
        }

        // Basic permutation. fixedChar are the characters already permuted and chars are the available ones
        public static IEnumerable<string> GetPermutations(string fixedChar, string chars)
        {
            List<string> ret = new List<string>();

            // If only one character left, just take it on the end
            if (chars.Length == 1)
                ret.Add(fixedChar + chars);

            // Loop through all the available characters and find all the permutations with the remaining characters
            for (int i = 0; i < chars.Length; i++)
                ret.AddRange(GetPermutations(fixedChar + chars[i], chars.Substring(0, i) + chars.Substring(i + 1, chars.Length - (i + 1))));

            return ret;
        }

        public static bool IsPalindrome(int input)
        {
            return IsPalindrome(input.ToString());
        }

        public static bool IsPalindrome(string input)
        {
            string firstHalf, secondHalf;

            // If we have a number that has an odd number of characters I want to ignore the middle one so it has special logic
            // Probably don't need the check but hey, completeness
            if (input.Length % 2 == 0)
            {
                firstHalf = input.Substring(0, input.Length / 2);
                secondHalf = input.Substring(input.Length / 2);
            }
            else
            {
                firstHalf = input.Substring(0, input.Length / 2);
                secondHalf = input.Substring(input.Length / 2 + 1);
            }

            // Reverse the text in the second half and just return if it equals the first half, easy
            secondHalf = new string(secondHalf.Reverse().ToArray());

            return firstHalf.Equals(secondHalf);
        }

        public static bool IsPandigital(string input)
        {
            return input.Length == 9 && digits.All(d => input.Contains(d)) ? true : false;
        }
    }
}
