#### [Gravity.Abstraction.Logging](./index.md 'index')
### [Gravity.Abstraction.Logging.Extensions](./Gravity-Abstraction-Logging-Extensions.md 'Gravity.Abstraction.Logging.Extensions').[LoggerExtensions](./Gravity-Abstraction-Logging-Extensions-LoggerExtensions.md 'Gravity.Abstraction.Logging.Extensions.LoggerExtensions')
## LoggerExtensions.AsReadableString(System.Collections.Generic.IDictionary&lt;string,object&gt;) Method
Converts a log message into a readable text message that can printed or saved to a file.  
```csharp
public static string AsReadableString(this System.Collections.Generic.IDictionary<string,object> logMessage);
```
#### Parameters
<a name='Gravity-Abstraction-Logging-Extensions-LoggerExtensions-AsReadableString(System-Collections-Generic-IDictionary-string_object-)-logMessage'></a>
`logMessage` [System.Collections.Generic.IDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')  
Log message to convert.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Readable [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') when can posted to console or into a file.  
