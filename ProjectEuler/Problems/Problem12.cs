using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem12 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int currentTriangularIndex = 7, triangularNumber = 28;
            List<int> divisors;

            do
            {
                divisors = new List<int>();

                // Add one to the index and add it to make the next triangular number
                currentTriangularIndex++;
                triangularNumber += currentTriangularIndex;

                // Find all the divisors below its square root (the halfway point for factors)
                for (int i = 1; i < Math.Sqrt(triangularNumber); i++)
                {
                    // If it divides evenly its a factor so add it and its reciprocal
                    if (triangularNumber % i == 0)
                    {
                        divisors.Add(i);
                        divisors.Add(triangularNumber / i);
                    }
                }
            } while (divisors.Count < 500);

            Console.WriteLine("Problem 12: " + triangularNumber);
        }
    }
}
