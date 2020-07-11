#### [Gravity.Abstraction.Logging](./index.md 'index')
### [Gravity.Abstraction.Logging](./Gravity-Abstraction-Logging.md 'Gravity.Abstraction.Logging').[LogFactory](./Gravity-Abstraction-Logging-LogFactory.md 'Gravity.Abstraction.Logging.LogFactory')
## LogFactory.Create&lt;T&gt;(object[]) Method
Creates a new [Logger](./Gravity-Abstraction-Logging-Logger.md 'Gravity.Abstraction.Logging.Logger') instance.  
```csharp
public static Gravity.Abstraction.Logging.ILogger Create<T>(params object[] args);
```
#### Type parameters
<a name='Gravity-Abstraction-Logging-LogFactory-Create-T-(object--)-T'></a>
`T`  
Type of [Logger](./Gravity-Abstraction-Logging-Logger.md 'Gravity.Abstraction.Logging.Logger') to create.  
  
#### Parameters
<a name='Gravity-Abstraction-Logging-LogFactory-Create-T-(object--)-args'></a>
`args` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
[Logger](./Gravity-Abstraction-Logging-Logger.md 'Gravity.Abstraction.Logging.Logger') constructor parameters.  
  
#### Returns
[ILogger](./Gravity-Abstraction-Logging-ILogger.md 'Gravity.Abstraction.Logging.ILogger')  
An [ILogger](./Gravity-Abstraction-Logging-ILogger.md 'Gravity.Abstraction.Logging.ILogger') interface representing your [Logger](./Gravity-Abstraction-Logging-Logger.md 'Gravity.Abstraction.Logging.Logger') type.  
