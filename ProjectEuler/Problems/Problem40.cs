using System;
using System.Text;

namespace ProjectEuler.Problems
{
    internal class Problem40 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            // There is probably a nice easy to find pattern here, but honestly, brute forcing it was too easy
            
            StringBuilder dec = new StringBuilder();

            int cur = 1;

            while (dec.Length < 1000000)
            {
                dec.Append(cur++);
            }

            long product = Convert.ToInt32(dec[0].ToString());
            product *= Convert.ToInt32(dec[9].ToString());
            product *= Convert.ToInt32(dec[99].ToString());
            product *= Convert.ToInt32(dec[999].ToString());
            product *= Convert.ToInt32(dec[9999].ToString());
            product *= Convert.ToInt32(dec[99999].ToString());
            product *= Convert.ToInt32(dec[999999].ToString());

            Console.WriteLine("Problem 40: " + product);
        }
    }
}
