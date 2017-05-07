using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem39 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int numSolutions = 0, max = 0;

            // Lots of math happens here and honestly its too much to put all the steps here, but solve a^2 + b^2 = c^2 and a + b + c = p for b, that gets you the equation in the if
            // Analyzing even/odd for a and b shows that the sum of a, b, and c is always even, thus only checking even p.

            for (int p = 2; p <= 1000; p += 2)
            {
                int currSolutions = 0;

                for (int a = 2; a < (p / 3); a++)
                {
                    if (p * (p - 2 * a) % (2 * (p - a)) == 0)
                    {
                        currSolutions++;
                    }
                }

                if (currSolutions > numSolutions)
                {
                    numSolutions = currSolutions;
                    max = p;
                }
            }

            Console.WriteLine("Problem 39: " + max);
        }
    }
}
