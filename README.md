# CsharpConsJob Library
### CsharpConsJob is a lightweight C# Library written by Berka Ayowa that helps you create & schedule C# jobs

>Latest version 1.0.3

To use the library, just  add the CsharpConsJobLib.dll and CsharpCron.dll references to you c# console project, they are located under Library folder
>##We recommended to install the latest library version 1.0.3 from Nuget, search CsharpConsJobLib from nuget and install.

```html
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
    .Add<Email>("*/30 * * ? * * *")

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
    .Add("0 0 9:50 ? * * *", new List<Job>(){ new NotificationReport(), new BalanceStatement()})

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
```

#### Property
| Name | Description | Example | 
| --- | --- | --- |
| Add | Add job class to the job to the registry .| JobRegistry.Instance.Add<NotificationReport>("* * * ? * *", Job) 

#### Events
| Name | Description | Example | 
| --- | --- | --- |
| OnException | This event get triggered when any error occures| JobRegistry.OnException += OnException
| OnLogEvent | This event get triggered to notify current job actions| JobRegistry.OnLogEvent += OnLog

#### Action
| Name | Description | Example | 
| --- | --- | --- |
| Run | This action starts runing the jobs availe in the job registry| JobRegistry.Instance.Run();

>#### Sample project can be found in Example folder

>For generating more cron expresions  you can check [here](https://www.freeformatter.com/cron-expression-generator-quartz.html) or email us on ayowaberka@gmail.com for assistance or just to say hello :)

>Click [here](https://www.paypal.com/donate/?hosted_button_id=3EUXREY22UMGQ) to donate for supporting us to keep improving this library  
