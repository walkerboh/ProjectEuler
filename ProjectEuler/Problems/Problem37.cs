using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem37 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int sum = 0, count = 0;
            int i = 11;

            while (count < 11)
            {
                if (Helper.IsPrime(i))
                {
                    bool all = true;
                    string numberString = i.ToString();

                    for (int j = 1; j < numberString.Length; j++)
                    {
                        string truncatedString = numberString.Substring(j, numberString.Length - j);
                        if (!Helper.IsPrime(Convert.ToInt32(truncatedString)))
                            all = false;
                    }

                    for (int j = numberString.Length - 1; j > 0 && all; j--)
                    {
                        string truncatedString = numberString.Substring(0, j);
                        if (!Helper.IsPrime(Convert.ToInt32(truncatedString)))
                            all = false;
                    }

                    if (all)
                    {
                        sum += i;
                        count++;
                    }
                }

                i++;
            }

            Console.WriteLine("Problem 37: " + sum);
        }
    }
}
