using System;
using System.Collections;
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

        public static IEnumerable<string> GetPermutations(string initialCharacters)
        {
            return GetPermutations(string.Empty, initialCharacters);
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

        public static bool IsPandigital(string input, int length, bool includeZero = false)
        {
            return input.Length == length && Enumerable.Range(includeZero ? 0 : 1, length).All(d => input.Contains(d.ToString())) ? true : false;
        }

        /// <summary>
        /// Method to generate primes using the Sieve of Eratoathenes
        /// I stole this from http://www.mathblog.dk/sum-of-all-primes-below-2000000-problem-10/ and modified it to yield return
        /// I got tired of always looping to generate primes so this works better if we know an upper limit
        /// </summary>
        /// <param name="upperLimit">Upper limit to find a prime</param>
        /// <returns>List of prime numbers</returns>
        public static IEnumerable<int> ESieve(int upperLimit)
        {
            int sieveBound = (int)(upperLimit - 1) / 2;
            int upperSqrt = ((int)Math.Sqrt(upperLimit) - 1) / 2;

            BitArray PrimeBits = new BitArray(sieveBound + 1, true);

            for (int i = 1; i <= upperSqrt; i++)
            {
                if (PrimeBits.Get(i))
                {
                    for (int j = i * 2 * (i + 1); j <= sieveBound; j += 2 * i + 1)
                    {
                        PrimeBits.Set(j, false);
                    }
                }
            }

            List<int> numbers = new List<int>((int)(upperLimit / (Math.Log(upperLimit) - 1.08366)));
            yield return 2;

            for (int i = 1; i <= sieveBound; i++)
            {
                if (PrimeBits.Get(i))
                {
                    yield return (2 * i + 1);
                }
            }
        }

        public static bool IsWholeNumber(double n)
        {
            return n == (long)n;
        }

        public static long GetTriangular(int n)
        {
            return (long)n * (n + 1) / 2;
        }

        public static bool IsTriangular(long n)
        {
            return IsWholeNumber((Math.Sqrt((8 * n) + 1) - 1) / 2);
        }

        public static long GetPentagonal(int n)
        {
            return (long)n * ((3 * n) - 1) / 2;
        }

        public static bool IsPentagonal(long n)
        {
            return IsWholeNumber((Math.Sqrt((24 * n) + 1) + 1) / 6);
        }

        public static long GetHexagonal(int n)
        {
            return (long)n * ((2 * n) - 1);
        }

        public static bool IsHexagonal(long n)
        {
            return IsWholeNumber((Math.Sqrt((8 * n) + 1) + 1) / 4);
        }
    }
}
