#### [Gravity.Abstraction.Logging](./index.md 'index')
### [Gravity.Abstraction.Logging](./Gravity-Abstraction-Logging.md 'Gravity.Abstraction.Logging').[ILogger](./Gravity-Abstraction-Logging-ILogger.md 'Gravity.Abstraction.Logging.ILogger')
## ILogger.Error(System.Func&lt;string&gt;) Method
Logs an error message with lazily constructed message. The message will be constructed only if the [IsErrorEnabled](./Gravity-Abstraction-Logging-ILogger-IsErrorEnabled.md 'Gravity.Abstraction.Logging.ILogger.IsErrorEnabled') is true.  
```csharp
void Error(System.Func<string> messageFactory);
```
#### Parameters
<a name='Gravity-Abstraction-Logging-ILogger-Error(System-Func-string-)-messageFactory'></a>
`messageFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')  
  
