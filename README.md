# CsharpConsJob Library
### CsharpConsJob is a lightweight C# Library written by Berka Ayowa that helps you create & shedule C# job

To use add the using CsharpConsJobLib.dll reference to you c# console project

```html
//Adding job in chain
JobRegistry.Instance
//Every second
.Add<NotificationReport>("* * * ? * *")
//Every mimutes
.Add<DaillyReport>("0 * * ? * *")
//Every Hour
.Add<BalanceStatement>("0 0 * ? * *")
.Run();
```

#### Property
| Name | Description | Example | 
| --- | --- | --- |
| Add | Add job class to the jobn registry .| JobRegistry.Instance.Add<NotificationReport>("* * * ? * *") 

#### Events
| Name | Description | Example | 
| --- | --- | --- |
| OnException | This event get triggered when any error occures| JobRegistry.OnException += OnException
| OnLogEvent | This event get triggered to notify current job actions| JobRegistry.OnLogEvent += OnLog