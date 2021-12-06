using CsharpConsJobLib.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpConsJob
{
    public class BalanceStatement : Job
    {
        public override void Run()
        {
            Thread.Sleep(10000);
        }

        public override void OnCompleted()
        {

        }

    }
}
