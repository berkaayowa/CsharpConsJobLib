using CsharpConsJobLib.Base;
using CsharpConsJobLib.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpConsJob
{
    class Program
    {
        static void Main(string[] args)
        {

            //Setting events
            JobRegistry.OnException += OnException;
            JobRegistry.OnLogEvent += OnLog;

            //Adding job in chain
            JobRegistry.Instance
             //Every second
            .Add<NotificationReport>("* * * ? * *")
            //Every 30 seconds
            .Add<NotificationReport>("*/30 * * ? * * *")
            //Every mimutes
            .Add<DaillyReport>("0 * * ? * *")
            //Every x minutes, example 2 minutes
            .Add<BalanceStatement>("0 */2 * ? * * *")
            //Every Hour
            .Add<BalanceStatement>("0 0 * ? * *")
            ////Every x hours, example  3 hours
            .Add<BalanceStatement>("0 0 */3 ? * * *")
            ////Every day at x time, example every day at 9:35
            .Add<NotificationReport>("0 0 9:35 ? * * *")
            //Add a list of jobs
            .Add("0 0 9:50 ? * * *", new List<Job>()
                {
                    new NotificationReport(),
                    new BalanceStatement()
                }
            )
            .Run();

        }

        public static void OnException(object source, Exception exception)
        {
            //Disaply error if any occures
            Console.WriteLine(DateTime.Now.ToString() + " - Exception - " + exception.Message);
        }

        public static void OnLog(object obj)
        {
            //You can alos log this to a file or just onscreen log
            Console.WriteLine(DateTime.Now.ToString() + " - " + obj.ToString());
        }

    }
}
