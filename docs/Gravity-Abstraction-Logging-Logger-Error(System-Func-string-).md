#### [Gravity.Abstraction.Logging](./index.md 'index')
### [Gravity.Abstraction.Logging](./Gravity-Abstraction-Logging.md 'Gravity.Abstraction.Logging').[Logger](./Gravity-Abstraction-Logging-Logger.md 'Gravity.Abstraction.Logging.Logger')
## Logger.Error(System.Func&lt;string&gt;) Method
Logs an "Error" message with lazily constructed message. The message will be constructed  
only if the IsErrorEnabled is true.  
```csharp
public void Error(System.Func<string> messageFactory);
```
#### Parameters
<a name='Gravity-Abstraction-Logging-Logger-Error(System-Func-string-)-messageFactory'></a>
`messageFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')  
A delegate for creating a log message.  
  
