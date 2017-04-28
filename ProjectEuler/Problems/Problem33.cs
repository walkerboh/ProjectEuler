using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem33 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            List<Tuple<int, int>> fractions = new List<Tuple<int, int>>();

            // Loop through all possible two digit (top and bottom) fractions less than 1
            for (int i = 10; i < 99; i++)
            {
                for (int j = i + 1; j < 100; j++)
                {
                    // If both are multiples of 10 skip, trivial case
                    if (i % 10 == 0 && j % 10 == 0)
                        continue;

                    string sNum = i.ToString();
                    string sDen = j.ToString();

                    // Get the matching digit
                    IEnumerable<char> matchedDigit = sNum.Intersect(sDen);

                    // Make sure there is a matching digit
                    if (matchedDigit.Count() == 0)
                        continue;

                    sNum = new string(sNum.Except(matchedDigit).ToArray());
                    sDen = new string(sDen.Except(matchedDigit).ToArray());

                    // If it was a repeated digit and we removed it, continue on
                    if (string.IsNullOrEmpty(sNum) || string.IsNullOrEmpty(sDen))
                        continue;

                    // Bad because this is NOT how you simplify a fraction
                    double badFrac = Convert.ToDouble(sNum) / Convert.ToDouble(sDen);

                    // If the fractions are equal, add it
                    if (badFrac == (double)i / j)
                        fractions.Add(Tuple.Create(i, j));
                }
            }

            int totalNum = 1;
            int totalDen = 1;

            // Get the multiple of the fraction
            fractions.ForEach(x => { totalNum *= x.Item1; totalDen *= x.Item2; });

            // Simplify it
            SimplifyFraction(ref totalNum, ref totalDen);

            Console.WriteLine("Problem 33: " + totalDen);
        }

        /// <summary>
        /// Simplifys a fraction
        /// </summary>
        /// <param name="num">Numerator</param>
        /// <param name="den">Denominator</param>
        private void SimplifyFraction(ref int num, ref int den)
        {
            int gcd;

            // While the two numbers don't have a gcd of 1, it can be simplified
            while ((gcd = Helper.GCD(num, den)) != 1)
            {
                num = num / gcd;
                den = den / gcd;
            }
        }

        
    }
}
