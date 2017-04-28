using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem35 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int count = 0;

            for (int i = 2; i < 1000000; i++)
            {
                if (Helper.IsPrime(i))
                {
                    List<string> rotations = new List<string>();

                    string num = i.ToString();

                    for (int j = 0; j < num.Length; j++)
                    {
                        char m = num.Last();
                        num = m + num.Substring(0, num.Length - 1);
                        rotations.Add(num);
                    }

                    IEnumerable<int> numbers = rotations.Select(s => Convert.ToInt32(s));

                    if (numbers.All(n => Helper.IsPrime(n)))
                        count++;
                }
            }

            Console.WriteLine("Problem 35: " + count);
        }
    }
}
