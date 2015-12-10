﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    static class Helper
    {
        // Simple prime checking algorithm alla the pseudocode found on https://en.wikipedia.org/wiki/Primality_test
        public static bool IsPrime(long number)
        {
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
    }
}
