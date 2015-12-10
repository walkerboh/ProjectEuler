using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem4 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int palindrome = 0;

            // Once again brute force all multiples. It doesn't take long and is quicker than checking 999*999 and subtracting 1 since we would need to factor
            for (int i = 999; i >= 100; i--)
            {
                for (int j = 999; j >= 100; j--)
                {
                    int temp;

                    // If its a palindrome and greater than the current one we have then save it.
                    if (IsPalindrome((temp = i * j)) && temp > palindrome)
                        palindrome = temp;
                }
            }

            Console.WriteLine("Problem 4: " + palindrome);

        }

        // Takes the number and does string manipulation to check from palindrome-ness (I like making up words)
        private bool IsPalindrome(int number)
        {
            string numberString = Convert.ToString(number);
            string firstHalf, secondHalf;

            // If we have a number that has an odd number of characters I want to ignore the middle one so it has special logic
            // Probably don't need the check but hey, completeness
            if (numberString.Length % 2 == 0)
            {
                firstHalf = numberString.Substring(0, numberString.Length / 2);
                secondHalf = numberString.Substring(numberString.Length / 2);
            }
            else
            {
                firstHalf = numberString.Substring(0, numberString.Length / 2);
                secondHalf = numberString.Substring(numberString.Length / 2 + 1);
            }

            // Reverse the text in the second half and just return if it equals the first half, easy
            secondHalf = new string(secondHalf.Reverse().ToArray());

            return firstHalf.Equals(secondHalf);
        }
    }
}
