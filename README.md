# Gravity Abstraction Logging
Gravity API, logging abstraction. Allows to create any type of logging output using standard conventions.

# Quick Start (using the existing ```TraceLogger```)
```csharp
/* 
 * if you want the log files to be save in the current directory, do not set "inDirectory" argument.
 */

var logger = new TraceLogger(applicationName: "myApplication", loggerName: "DataClass", inDirectory: @"C:\Logs");
logger.Debug(message: "This is a debug message");
```

# Implement Your Own Message Handling
```csharp
/* 
 * You must inherit Logger class.
 */

public class HttpLogger : Logger
{
    private readonly string baseAddress;
    private readonly string applicationName;
    private static readonly HttpClient client = new HttpClient();

    // Will be used to pass values into next constructor.
    public HttpLogger(string applicationName, string loggerName)
       : this(applicationName, loggerName, baseAddress: "http://localhost:5000/")
    { }

    // Custom constructor to take some HTTP Context.
    public HttpLogger(string applicationName, string loggerName, string baseAddress)
       : base(applicationName, loggerName)
    {
        this.baseAddress = baseAddress;
        this.applicationName = applicationName;
        client.BaseAddress = new Uri(baseAddress);
    }

    // Creates a child logger with the same application name.
    public override ILogger CreateChildLogger(string loggerName)
    {
        return new HttpLogger(applicationName, loggerName, baseAddress);
    }

    // Override the message parsing and sending.
    // At this point the logMessage is already populated and you can change it before sending.
    public override void OnExecutor(string level, IDictionary<string, object> logMessage)
    {
        // some message manipulation
        logMessage["EndPoint"] = $"{baseAddress}/logging";
        logMessage["LogType"] = nameof(HttpLogger);
        
        // setup
        var requestBody = JsonConvert.SerializeObject(logMessage);
        var content = new StringContent(content: requestBody, Encoding.UTF8, mediaType: "application/json");

        // send
        client.PostAsync("/loggingServe", content).GetAwaiter().GetResult();
    }
}

/* 
 * if you want the log files to be sent to "http://localhost:5000", do not set "baseAddress" argument.
 */

var logger = new HttpLogger(applicationName: "myApplication", loggerName: "DataClass", baseAddress: @"http://loggingserver/");
logger.Debug(message: "This is a debug message");
```