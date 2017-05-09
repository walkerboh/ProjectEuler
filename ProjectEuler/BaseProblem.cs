using System;
using System.Diagnostics;

namespace ProjectEuler
{
    internal class BaseProblem
    {
        public TimeSpan Run()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ExecuteProblem();
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        protected virtual void ExecuteProblem()
        {
            throw new NotImplementedException();
        }
    }
}
