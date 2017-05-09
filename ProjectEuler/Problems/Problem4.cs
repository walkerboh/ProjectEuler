using System;

namespace ProjectEuler.Problems
{
    internal class Problem4 : BaseProblem
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
                    if (Helper.IsPalindrome((temp = i * j)) && temp > palindrome)
                        palindrome = temp;
                }
            }

            Console.WriteLine("Problem 4: " + palindrome);

        }
    }
}
