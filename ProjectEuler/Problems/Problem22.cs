using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectEuler.Problems
{
    internal class Problem22 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            List<string> names = new List<string>();

            // Read in all the names and split on the comma
            using (StreamReader reader = new StreamReader(Helper.GetArtifactFilePath("p022_names.txt")))
            {
                names.AddRange(reader.ReadToEnd().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            }

            // Sort the names
            names.Sort();

            long sum = 0;

            // For each name (need the index)
            for (int i = 0; i < names.Count; i++)
            {
                // Get rid of the quotes and get the characters
                char[] characters = names[i].Trim('"').ToCharArray();
                int nameSum = 0;

                //Sum all the character values (A is ASCII 65 so subtract 64)
                foreach (char character in characters)
                {
                    nameSum += ((Convert.ToInt32(character)) - 64);
                }

                // Multiply the letter sum by the index (0 based index so add 1) and add to the total
                sum += ((i + 1) * nameSum);
            }

            Console.WriteLine("Problem 22: " + sum);
        }
    }
}
