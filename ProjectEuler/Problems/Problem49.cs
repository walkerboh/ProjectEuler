using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem49 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int i = 1000;

            while (i < 10000)
            {
                IEnumerable<string> permutations = Helper.GetPermutations(i.ToString());

                // Get all the permutations that are 4 digit primes
                List<int> primes = permutations.Distinct().Select(p => Convert.ToInt32(p)).Where(p => Helper.IsPrime(p) && p >= 1000).ToList();

                // If there are at least three primes and none of them are the example test them
                if (!primes.Any(p => p == 1487) && primes.Count >= 3)
                {
                    // sort the list
                    primes.Sort();

                    // Pull three from the list, if the differences are equal, we solved the problem.
                    for (int j = 0; j < primes.Count - 2; j++)
                        for (int k = j + 1; k < primes.Count - 1; k++)
                            for (int l = k + 1; l < primes.Count; l++)
                            {
                                int a = primes[j], b = primes[k], c = primes[l];

                                if (b - a == c - b)
                                {
                                    Console.WriteLine(string.Concat("Problem 49: ", a, b, c));
                                    return;
                                }
                            }
                }

                i++;
            }

            Console.WriteLine("Problem 49 finshed with no solution.");
        }
    }
}
