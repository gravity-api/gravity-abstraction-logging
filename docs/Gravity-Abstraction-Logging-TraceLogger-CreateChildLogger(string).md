#### [Gravity.Abstraction.Logging](./index.md 'index')
### [Gravity.Abstraction.Logging](./Gravity-Abstraction-Logging.md 'Gravity.Abstraction.Logging').[TraceLogger](./Gravity-Abstraction-Logging-TraceLogger.md 'Gravity.Abstraction.Logging.TraceLogger')
## TraceLogger.CreateChildLogger(string) Method
Creates a new instance of [Logger](./Gravity-Abstraction-Logging-Logger.md 'Gravity.Abstraction.Logging.Logger'), with the same application name and a different logger name.  
```csharp
public override Gravity.Abstraction.Logging.ILogger CreateChildLogger(string loggerName);
```
#### Parameters
<a name='Gravity-Abstraction-Logging-TraceLogger-CreateChildLogger(string)-loggerName'></a>
`loggerName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Logger name.  
  
#### Returns
[ILogger](./Gravity-Abstraction-Logging-ILogger.md 'Gravity.Abstraction.Logging.ILogger')  
A new instance of [Logger](./Gravity-Abstraction-Logging-Logger.md 'Gravity.Abstraction.Logging.Logger').  
