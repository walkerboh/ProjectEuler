using System;

namespace ProjectEuler.Problems
{
    internal class Problem6 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            double sumOfSquares = 0;
            double squareOfSums = 0;

            // Sum the squares for the first, make the sum for the second
            for (int i = 1; i <= 100; i++)
            {
                sumOfSquares += Math.Pow(i, 2);
                squareOfSums += i;
            }

            // Square the sum
            squareOfSums = Math.Pow(squareOfSums, 2);

            // Subtract!
            Console.WriteLine("Problem 6: " + (squareOfSums - sumOfSquares));
        }
    }
}
