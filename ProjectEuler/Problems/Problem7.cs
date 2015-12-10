using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem7 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            List<long> primes = new List<long> { 2, 3 };
            long currentNum = 3;

            // Once again about as brute force as you can get, still runs really quick
            while (primes.Count != 10001)
            {
                currentNum += 2;

                if (Helper.IsPrime(currentNum))
                    primes.Add(currentNum);
            }

            Console.WriteLine("Problem 7: " + primes.Last());
        }
    }
}
