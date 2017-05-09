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
            // Brute force but works fast enough
            // Also C# math is dumb and in the calculation of the triangular numbers, a variable needs to be casted to long since I give it an int, otherwise multiplication overflows

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
