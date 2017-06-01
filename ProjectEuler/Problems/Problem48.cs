using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem48 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            // I know there is some fancy modulo math I could, but this is really fast. Why bother...
            BigInteger bigInt = new BigInteger();
            bigInt = 0;

            for (int i = 1; i <= 1000; i++)
                bigInt += BigInteger.Pow(i, i);

            Console.WriteLine("Problem 48: " + bigInt.ToString().Substring(bigInt.ToString().Length - 10));
        }
    }
}
