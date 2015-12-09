using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class BaseProblem
    {
        public TimeSpan Run()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ExecuteProblem();
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        virtual protected void ExecuteProblem()
        {
            throw new NotImplementedException();
        }
    }
}
