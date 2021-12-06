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
           // JobRegistry.OnException += OnException;
            //JobRegistry.OnLogEvent += OnLog;

            //Adding job in chain
            JobRegistry.Instance
             //Every second
            .Add<NotificationReport>("* * * ? * *")
            //Every mimutes
            .Add<DaillyReport>("0 * * ? * *")
            //Every Hour
            .Add<BalanceStatement>("0 0 * ? * *")
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
