using System;

namespace ProjectEuler.Problems
{
    internal class Problem5 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int number = 0;
            bool done = false;

            // Super brute force but with some tricks to make it quicker. Could have gone the LCM and GCD method, but this was quicker to type up with no built-ins (that I know of)
            while (!done)
            {
                // I chose 180 because I knew this would handle most of the numbers smaller than 20 because of its factors, leaving me with only 7 numbers to check.
                // Not a lot but it does help speed things up
                number += 180;

                if (number % 19 == 0 && number % 17 == 0 && number % 16 == 0 && number % 14 == 0 && number % 13 == 0 && number % 11 == 0 && number % 7 == 0)
                    done = true;
            }

            Console.WriteLine("Problem 5: " + number);

        }
    }
}
