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
                pentagonal.Add(GetPentagonal(n));

                for (int i = 0; i < pentagonal.Count - 1; i++)
                {
                    if (IsPentagonal(pentagonal.ElementAt(n - 1) - pentagonal.ElementAt(i)) && IsPentagonal(pentagonal.ElementAt(n - 1) + pentagonal.ElementAt(i)))
                    {
                        solved = true;
                        Console.WriteLine("Problem 44: " + Math.Abs(pentagonal.ElementAt(n - 1) - pentagonal.ElementAt(i)));
                    }
                }

                n++;
            }
        }

        private int GetPentagonal(int n)
        {
            return n * ((3 * n) - 1) / 2;
        }

        private bool IsPentagonal(int n)
        {
            return pentagonal.Contains(n) || Helper.IsWholeNumber((Math.Sqrt((24 * n) + 1) + 1) / 6);
        }
    }
}
