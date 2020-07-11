#### [Gravity.Abstraction.Logging](./index.md 'index')
### [Gravity.Abstraction.Logging](./Gravity-Abstraction-Logging.md 'Gravity.Abstraction.Logging').[ILogger](./Gravity-Abstraction-Logging-ILogger.md 'Gravity.Abstraction.Logging.ILogger')
## ILogger.CreateChildLogger(string) Method
Create a new child logger.  
The name of the child logger is [current-loggers-name].[passed-in-name]  
```csharp
Gravity.Abstraction.Logging.ILogger CreateChildLogger(string loggerName);
```
#### Parameters
<a name='Gravity-Abstraction-Logging-ILogger-CreateChildLogger(string)-loggerName'></a>
`loggerName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The sub-name of this logger.  
  
#### Returns
[ILogger](./Gravity-Abstraction-Logging-ILogger.md 'Gravity.Abstraction.Logging.ILogger')  
The New ILogger instance.  
#### Exceptions
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
If the name has an empty element name.  
