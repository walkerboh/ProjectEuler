using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem17 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            long sum = 0;

            for (int i = 1; i <= 1000; i++)
                sum += NumberToText(i).Length;

            Console.WriteLine("Problem 17: " + sum);
        }

        public string NumberToText(int n)
        {
            // Definte the strings for 1-19
            string[] onesTeens = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen","Fifteen","Sixteen","Seventeen"
            ,"Eighteen", "Nineteen"};

            // Define the strings for 10s digits
            string[] tens = { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            // Return the highest amount we can parse out plus the lower amount
            if (n == 0)
                return "";
            else if (n < 20)
                return onesTeens[n - 1];
            else if (n < 100)
                return tens[n / 10 - 2] + NumberToText(n % 10);
            else if (n < 1000)
            {
                if (n % 100 == 0)
                    return NumberToText(n / 100) + "Hundred";
                else
                    return NumberToText(n / 100) + "HundredAnd" + NumberToText(n % 100);
            }
            else if (n == 1000)
                return "OneThousand";
            else
                return "";
        }
    }
}
