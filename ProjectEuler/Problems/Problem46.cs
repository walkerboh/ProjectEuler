using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    internal class Problem46 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int i = 9;

            while (true)
            {
                if (Helper.IsPrime(i))
                {
                    i += 2;
                    continue;
                }

                bool found = false;

                foreach (int s in Helper.ESieve(i))
                {
                    int p = 1;

                    while (s + 2 * p * p < i)
                    {
                        p++;
                    }

                    if (s + 2 * p * p == i)
                        found = true;
                }

                if (!found)
                {
                    Console.WriteLine("Problem 46: " + i);
                    return;
                }

                i += 2;
            }
        }
    }
}
