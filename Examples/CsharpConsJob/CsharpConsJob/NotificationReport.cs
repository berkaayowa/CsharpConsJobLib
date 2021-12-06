using CsharpConsJobLib.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpConsJob
{
    public class NotificationReport : Job
    {
        public override void Run()
        {
            Thread.Sleep(5000);
        }

    }
}
