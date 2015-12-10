using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem9 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            double product = 0;
            bool done = false;

            // Let's brute force it again! Shouldn't take too long really
            for (double a = 1; a < 1000; a++) // < 1000 sanity check, shouldn't ever get that far but I need an upper bound
            {
                for (double b = a + 1; a + b < 1000; b++) // a < b so b starts at a + 1; Also <1000 for hard stop to try new a value
                {
                    double c;

                    if (a + b + (c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2))) == 1000)
                    {
                        product = a * b * c;
                        done = true;
                        break;
                    }
                }

                if (done)
                    break;
            }

            Console.WriteLine("Problem 9: " + product);
        }
    }
}
