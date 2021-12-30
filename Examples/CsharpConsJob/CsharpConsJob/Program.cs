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
            //Setup a Function to call if any error occured 'OnException'
            JobRegistry.OnException += OnException;

            //This 'OnLogEvent' method is depreciated
            //JobRegistry.OnLogEvent += OnLog;

            //Setup a Function to print job activy on the console 'OnJobLog'
            JobRegistry.OnJobLogEvent += OnJobLog;

            //Adding job in chain
            JobRegistry.Instance

             //Every second
             //.Add<NotificationReport>("* * * ? * * *")

             //Every x seconds e.g every 30 seconds
             .Add<DaillyReport>("*/30 * * ? * * *")

             //Every mimutes
             //.Add<DaillyReport>("0 * * ? * * *")

             //Every x minutes e.g Every 2 minutes
             //.Add<SMS>("0 */1 * ? * * *")

             //Every Hour
             //.Add<BalanceStatement>("0 0 * ? * * *")

             //Every x hour e.g Every 2 hours
             //.Add<BalanceStatement>("0 0 */2 ? * * *")
             //.Add<NotificationReport>("0 0 14 19 * * *")

             //Every day at x hours e.g Every at 00:00
             //.Add<NotificationReport>("0 0 9 ? * * *")

             //Every day at x time e.g Every at 00:30
             //.Add<NotificationReport>("0 0 9:35 ? * * *")

             //Add a list of jobs , this functionality is available in version 1.0.2 up
             .Add("0 0 9:50 ? * * *", new List<Job>() { new NotificationReport(), new BalanceStatement() })

             //CmdCommand.Execute is available in version 1.0.3 up
             //Run cmd command every x seconds e.g executing 'ipconfig' command every 10 seconds
             .Add("*/10 * * ? * * *", CmdCommand.Execute("ipconfig", (string result) =>
             {
                 // Display the command output.
                 Console.WriteLine(result);
             }))

             //Run cmd command every x seconds e.g cd in test folder and run git pull command every 10 seconds
             .Add("*/15 * * ? * * *", CmdCommand.Execute(@"cd C:\test&git pull", (string result) => {
                 // Display the command output.
                 Console.WriteLine(result);
             }))


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

        public static void OnJobLog(LogType logType, object obj)
        {
            //You can alos log this to a file or just onscreen log
            Console.WriteLine(DateTime.Now.ToString() + " - " + obj.ToString());
        }

    }
}
