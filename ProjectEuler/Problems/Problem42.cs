using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler.Problems
{
    internal class Problem42 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            // Note: I converted words.txt to have the words on new lines for ease of use
            IEnumerable<string> words = File.ReadLines(Helper.GetArtifactFilePath("p042_words.txt"));

            List<int> wordValues = new List<int>();
            int max = 0;

            // Convert all the words to their value and add it to a list
            foreach (string word in words)
            {
                int wordValue = 0;

                foreach (char character in word)
                {
                    // Everything is capitalized so drop 64 from ASCII value
                    wordValue += character - 64;
                }

                wordValues.Add(wordValue);

                // Track the maximum word value
                max = Math.Max(max, wordValue);
            }

            List<int> triangleNumbers = new List<int>();
            int n = 1;

            // Generate triangle numbers until we are larger than the largest word
            while (triangleNumbers.Max() < max)
            {
                triangleNumbers.Add((int)(.5 * n * (n + 1)));
                n++;
            }

            int count = 0;

            // Loop through the triangle numbers and find them in the list of word values
            //  Faster to loop these rather than the word values since there are certainly less triangle numbers to loop over
            foreach (int triangleNumber in triangleNumbers)
            {
                count += wordValues.Count(v => v == triangleNumber);
            }

            Console.WriteLine("Problem 42: " + count);
        }
    }
}
