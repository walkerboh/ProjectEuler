using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem18 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            // Yay jagged arrays. First index is the row number, second is the "column"
            int[][] triangle = { new int[] { 75 }, new int[] { 95, 64 }, new int[] { 17, 47, 82 }, new int[] { 18, 35, 87, 10 }, new int[] { 20, 04, 82, 47, 65 }, new int[] { 19, 01, 23, 75, 03, 34 }, new int[] { 88, 02, 77, 73, 07, 63, 67 }, new int[] { 99, 65, 04, 28, 06, 16, 70, 92 }, new int[] { 41, 41, 26, 56, 83, 40, 80, 70, 33 }, new int[] { 41, 48, 72, 33, 47, 32, 37, 16, 94, 29 }, new int[] { 53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14 }, new int[] { 70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57 }, new int[] { 91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48 }, new int[] { 63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31 }, new int[] { 04, 62, 98, 27, 23, 09, 70, 98, 73, 93, 38, 53, 60, 04, 23 } };

            // Store all the max sums at each postion by tuple <row, col, sum>
            List<Tuple<int, int, long>> sums = new List<Tuple<int, int, long>>();

            // Add the values for the bottom row
            for (int i = 0; i < 15; i++)
            {
                sums.Add(new Tuple<int, int, long>(14, i, triangle[14][i]));
            }

            // Find the sums for each row starting from the bottom
            for (int i = 13; i >= 0; i--)
            {
                // Sum each position, there are the same numbers of elements as the row number (0 based of course)
                for (int j = 0; j <= i; j++)
                {
                    long leftValue, rightValue;
                    
                    // Value for the left is at the same column position, value to the right is col + 1
                    leftValue = sums.Single(t => t.Item1 == i + 1 && t.Item2 == j).Item3;
                    rightValue = sums.Single(t => t.Item1 == i + 1 && t.Item2 == j + 1).Item3;

                    sums.Add(new Tuple<int, int, long>(i, j, Math.Max(triangle[i][j] + leftValue, triangle[i][j] + rightValue)));
                }
            }

            Console.WriteLine("Problem 18: " + sums.Single(t => t.Item1 == 0 && t.Item2 == 0).Item3);
        }
    }
}
