using System;

namespace ProjectEuler.Problems
{
    internal class Problem31 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int ways = 0;

            // Brute force add all the ways by looping through all possible values
            for (int a = 200; a >= 0; a -= 200)
                for (int b = a; b <= 200; b += 100)
                    for (int c = b; c <= 200; c += 50)
                        for (int d = c; d <= 200; d += 20)
                            for (int e = d; e <= 200; e += 10)
                                for (int f = e; f <= 200; f += 5)
                                    for (int g = f; g <= 200; g += 2)
                                        ways++;

            Console.WriteLine("Problem 31: " + ways);
        }
    }
}
