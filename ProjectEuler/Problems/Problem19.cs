using System;

namespace ProjectEuler.Problems
{
    internal class Problem19 : BaseProblem
    {
        protected override void ExecuteProblem()
        {
            int total = 0;

            DateTime dateTime = new DateTime(1901, 1, 1);

            // Some may call this cheating but it is within the bounds of the challenge.
            // You could use the average day distribution of days between the dates divided by 7 for days of the week and 30 for days in the month. It gets you close.
            // Or you could calculate the days in each month in each year and one by one check if that loops around to a sunday with % but this is easier.
            while (dateTime <= new DateTime(2000, 12, 31))
            {
                if (dateTime.DayOfWeek == DayOfWeek.Sunday)
                    total++;

                dateTime = dateTime.AddMonths(1);
            }

            Console.WriteLine("Problem 19: " + total);
        }
    }
}
