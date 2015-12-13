using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem28 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            // Generate the grid as a list of tuples in the form <X, Y, value> where (0,0) is the center
            List<Tuple<int, int, int>> grid = GenerateGrid(500).ToList();

            // Get all the values on the diagonals, where x==y || x==-y
            List<int> values = grid.Where(cell => cell.Item1 == cell.Item2 || cell.Item1 == -cell.Item2).Select(cell => cell.Item3).ToList();

            Console.WriteLine("Problem 28: " + values.Sum());
        }

        private int count = 1;

        // Returns the list of tuples for a grid of specified radius
        private IEnumerable<Tuple<int, int, int>> GenerateGrid(int radius)
        {
            // Builds the ring for each radius
            foreach (int rad in Enumerable.Range(0, radius + 1))
            {
                foreach (Tuple<int, int, int> coordinateSum in GenerateRing(rad))
                {
                    yield return coordinateSum;
                }
            }
        }

        private IEnumerable<Tuple<int, int, int>> GenerateRing(int radius)
        {
            // The first point in the ring, start the x value as the radius from the center, the y value as the radius - 1 since we start in the top right but down one spot
            Tuple<int, int, int> currentPoint = new Tuple<int, int, int>(radius, 0 + Math.Max((radius - 1), 0), count++);
            yield return currentPoint;

            // Move down
            while (-radius < currentPoint.Item2)
            {
                currentPoint = new Tuple<int, int, int>(currentPoint.Item1, currentPoint.Item2 - 1, count++);
                yield return currentPoint;
            }

            // Move left
            while (-radius < currentPoint.Item1)
            {
                currentPoint = new Tuple<int, int, int>(currentPoint.Item1 - 1, currentPoint.Item2, count++);
                yield return currentPoint;
            }

            // Move up
            while (currentPoint.Item2 < radius)
            {
                currentPoint = new Tuple<int, int, int>(currentPoint.Item1, currentPoint.Item2 + 1, count++);
                yield return currentPoint;
            }

            // Move right
            while (currentPoint.Item1 < radius)
            {
                currentPoint = new Tuple<int, int, int>(currentPoint.Item1 + 1, currentPoint.Item2, count++);
                yield return currentPoint;
            }
        }
    }
}
