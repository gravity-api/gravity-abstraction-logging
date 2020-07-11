#### [Gravity.Abstraction.Logging](./index.md 'index')
### [Gravity.Abstraction.Logging](./Gravity-Abstraction-Logging.md 'Gravity.Abstraction.Logging').[ILogger](./Gravity-Abstraction-Logging-ILogger.md 'Gravity.Abstraction.Logging.ILogger')
## ILogger.Warn(System.Func&lt;string&gt;) Method
Logs a warn message with lazily constructed message. The message will be constructed only if the [IsWarnEnabled](./Gravity-Abstraction-Logging-ILogger-IsWarnEnabled.md 'Gravity.Abstraction.Logging.ILogger.IsWarnEnabled') is true.  
```csharp
void Warn(System.Func<string> messageFactory);
```
#### Parameters
<a name='Gravity-Abstraction-Logging-ILogger-Warn(System-Func-string-)-messageFactory'></a>
`messageFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')  
  
