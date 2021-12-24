# CsharpConsJob Library
### CsharpConsJob is a lightweight C# Library written by Berka Ayowa that helps you create & schedule C# jobs

To use the library, just  add the CsharpConsJobLib.dll and CsharpCron.dll references to you c# console project, they are located under Library folder
>##We recommended to install the library from Nuget, search CsharpConsJobLib from nuget and install.

```html
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

#### Sample project can be found in Example folder
>#### For generating more cron expresions  you can check [here](https://www.freeformatter.com/cron-expression-generator-quartz.html) or email us on ayowaberka@gmail.com
