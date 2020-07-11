#### [Gravity.Abstraction.Logging](./index.md 'index')
### [Gravity.Abstraction.Logging](./Gravity-Abstraction-Logging.md 'Gravity.Abstraction.Logging').[LogFactory](./Gravity-Abstraction-Logging-LogFactory.md 'Gravity.Abstraction.Logging.LogFactory')
## LogFactory.Create&lt;T&gt;(string, string) Method
Creates a new [Logger](./Gravity-Abstraction-Logging-Logger.md 'Gravity.Abstraction.Logging.Logger') instance.  
```csharp
public static Gravity.Abstraction.Logging.ILogger Create<T>(string applicationName, string loggerName);
```
#### Type parameters
<a name='Gravity-Abstraction-Logging-LogFactory-Create-T-(string_string)-T'></a>
`T`  
Type of [Logger](./Gravity-Abstraction-Logging-Logger.md 'Gravity.Abstraction.Logging.Logger') to create.  
  
#### Parameters
<a name='Gravity-Abstraction-Logging-LogFactory-Create-T-(string_string)-applicationName'></a>
`applicationName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Application name.  
  
<a name='Gravity-Abstraction-Logging-LogFactory-Create-T-(string_string)-loggerName'></a>
`loggerName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Logger name.  
  
#### Returns
[ILogger](./Gravity-Abstraction-Logging-ILogger.md 'Gravity.Abstraction.Logging.ILogger')  
An [ILogger](./Gravity-Abstraction-Logging-ILogger.md 'Gravity.Abstraction.Logging.ILogger') interface representing your [Logger](./Gravity-Abstraction-Logging-Logger.md 'Gravity.Abstraction.Logging.Logger') type.  
