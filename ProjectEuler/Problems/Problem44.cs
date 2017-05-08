using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem44 : BaseProblem
    {
        List<int> pentagonal = new List<int>() { 1 };

        protected override void ExecuteProblem()
        {
            int n = 2;
            bool solved = false;

            while (!solved)
            {
                pentagonal.Add(Helper.GetPentagonal(n));

                for (int i = 0; i < pentagonal.Count - 1; i++)
                {
                    if (Helper.IsPentagonal(pentagonal.ElementAt(n - 1) - pentagonal.ElementAt(i)) && Helper.IsPentagonal(pentagonal.ElementAt(n - 1) + pentagonal.ElementAt(i)))
                    {
                        solved = true;
                        Console.WriteLine("Problem 44: " + Math.Abs(pentagonal.ElementAt(n - 1) - pentagonal.ElementAt(i)));
                    }
                }

                n++;
            }
        }
    }
}
