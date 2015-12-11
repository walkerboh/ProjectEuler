using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem67 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int[][] triangle = new int[100][];

            string[] lines;

            // Read in the file, this will only work if you are running from within VS or haven't changed the file structure after building. Sorry
            using (StreamReader reader = new StreamReader(Helper.GetArtifactFilePath("p067_triangle.txt")))
            {
                // Read the whole file and split it into lines
                lines = reader.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            }

            int n = 0;

            foreach (string line in lines)
            {
                // Split the lines into the individual numbers
                string[] numbers = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                List<int> values = new List<int>();

                // Build the list of numbers in the row
                foreach (string number in numbers)
                {
                    values.Add(Convert.ToInt32(number));
                }

                // Add them to the triangle.
                triangle[n] = values.ToArray();

                n++;
            }

            // Store all the max sums at each postion by tuple <row, col, sum>
            List<Tuple<int, int, long>> sums = new List<Tuple<int, int, long>>();

            // Add the values for the bottom row
            for (int i = 0; i < 100; i++)
            {
                sums.Add(new Tuple<int, int, long>(99, i, triangle[99][i]));
            }

            // Find the sums for each row starting from the bottom
            for (int i = 98; i >= 0; i--)
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

            Console.WriteLine("Problem 67: " + sums.Single(t => t.Item1 == 0 && t.Item2 == 0).Item3);
        }
    }
}
