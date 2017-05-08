using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem43 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            long sum = 0;

            IEnumerable<string> permutations = Helper.GetPermutations("0123456789").Where(s => !s.StartsWith("0"));

            foreach(string permutation in permutations)
            {
                if (Helper.IsPandigital(permutation, 10, true))
                {
                    int div2 = Convert.ToInt32(permutation.Substring(1, 3));
                    int div3 = Convert.ToInt32(permutation.Substring(2, 3));
                    int div5 = Convert.ToInt32(permutation.Substring(3, 3));
                    int div7 = Convert.ToInt32(permutation.Substring(4, 3));
                    int div11 = Convert.ToInt32(permutation.Substring(5, 3));
                    int div13 = Convert.ToInt32(permutation.Substring(6, 3));
                    int div17 = Convert.ToInt32(permutation.Substring(7, 3));

                    if (div2 % 2 == 0 && div3 % 3 == 0 && div5 % 5 == 0 && div7 % 7 == 0 && div11 % 11 == 0 && div13 % 13 == 0 && div17 % 17 == 0)
                        sum += Convert.ToInt64(permutation);
                }
            }

            Console.WriteLine("Problem 43: " + sum);
        }
    }
}
