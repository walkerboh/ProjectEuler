using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem1 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int sum = 0;

            for (int i = 1; i < 1000; i++)
                if ((i % 3) == 0 || (i % 5) == 0)
                    sum += i;

            Console.WriteLine("Problem 1: " + sum);
        }
    }
}
