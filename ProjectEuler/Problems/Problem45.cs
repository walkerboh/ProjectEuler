using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem45 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            long newTriangular;
            int n = 286;

            while (true)
            {
                newTriangular = Helper.GetTriangular(n++);

                if (Helper.IsPentagonal(newTriangular) && Helper.IsHexagonal(newTriangular))
                {
                    Console.WriteLine("Problem 45: " + newTriangular);
                    return;
                }
            }
        }
    }
}
