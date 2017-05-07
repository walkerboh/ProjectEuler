using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem38 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            long max = 0;

            for (int i = 1; i < 10000; i++)
            {
                StringBuilder numString = new StringBuilder();

                int cur = i, mult = 1;

                while (numString.Length < 9)
                {
                    numString.Append((cur = (cur * mult++)));
                }

                if (numString.Length != 9)
                    continue;

                if (Helper.IsPandigital(numString.ToString()))
                {
                    max = Math.Max(max, Convert.ToInt32(numString.ToString()));
                }
            }

            Console.WriteLine("Problem 38: " + max);
        }
    }
}
