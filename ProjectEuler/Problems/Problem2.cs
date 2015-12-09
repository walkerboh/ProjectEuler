using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem2 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int sum = 0;

            int a = 1, b = 2;

            while (b < 4000000)
            {
                if (b % 2 == 0)
                    sum += b;

                int temp = a + b;
                a = b;
                b = temp;
            }

            Console.WriteLine("Problem 2: " + sum);
        }
    }
}
