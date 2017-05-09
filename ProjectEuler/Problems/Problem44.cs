using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    internal class Problem44 : BaseProblem
    {
        private List<long> pentagonal = new List<long>() { 1 };

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
