using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem52 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int num = 1;
            int scale = 1;

            while (true)
            {
                // If 6 times the number has more digits, jump to the next magnitude to save time
                if (num.ToString().Length < (num * 6).ToString().Length)
                {
                    scale *= 10;
                    num = scale;
                }

                // Get a list of the numbers as strings
                List<string> characters = new List<string>() { num.ToString(), (num * 2).ToString(), (num * 3).ToString(), (num * 4).ToString(), (num * 5).ToString(), (num * 6).ToString() };
                int length = characters[0].ToString().Length;

                // First check they are all the same length
                if (characters.All(c => c.ToString().Length == length))
                {
                    bool found = true;

                    // I struggled a lot here trying to be fancy joining character arrays and checking length but repeating numbers ruined my time
                    //  Finally made a permutation checker
                    for (int i = 1; i < characters.Count && found; i++)
                        found = found && Helper.IsPermutation(characters[0], characters[i]);

                    if (found)
                        break;
                }

                num++;
            }

            Console.WriteLine("Problem 52: " + num);
        }
    }
}
