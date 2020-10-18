/*
 * CHANGE LOG - keep only last 5 threads
 */
using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using Gravity.Abstraction.Logging.Extensions;

namespace Gravity.Abstraction.Logging
{
    /// <summary>
    /// <see cref="Logger"/> implementation for <see cref="Trace"/> logging.
    /// </summary>
    public class TraceLogger : Logger
    {
        // constants
        private const StringComparison Compare = StringComparison.OrdinalIgnoreCase;

        // members: state
        private readonly string applicationName;

        /// <summary>
        /// Creates a new <see cref="Logger"/> instance.
        /// </summary>
        /// <param name="applicationName">Application under logging.</param>
        /// <param name="loggerName">Logger name.</param>
        public TraceLogger(string applicationName, string loggerName)
            : this(applicationName, loggerName, inDirectory: string.Empty)
        { }

        /// <summary>
        /// Creates a new <see cref="Logger"/> instance.
        /// </summary>
        /// <param name="applicationName">Application under logging.</param>
        /// <param name="loggerName">Logger name.</param>
        /// <param name="inDirectory">The directory path in which to write the logs.</param>
        public TraceLogger(string applicationName, string loggerName, string inDirectory)
            : base(applicationName, loggerName)
        {
            // set logger state
            this.applicationName = applicationName;

            // setup listeners
            SetupTraceListener(instanceName: applicationName, inDirectory);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Logger"/>, with the same application name and a different logger name.
        /// </summary>
        /// <param name="loggerName">Logger name.</param>
        /// <returns>A new instance of <see cref="Logger"/>.</returns>
        public override ILogger CreateChildLogger(string loggerName)
        {
            return new TraceLogger(applicationName, loggerName);
        }

        /// <summary>
        /// Executes a single log request against this <see cref="Logger"/>.
        /// </summary>
        /// <param name="level">Log level.</param>
        /// <param name="logMessage">Message to log.</param>
        public override void OnExecutor(string level, IDictionary<string, object> logMessage)
        {
            // setup conditions
            var isInfo = level.Equals(LogLevel.Information, Compare);
            var isError = level.Equals(LogLevel.Error, Compare) || level.Equals(LogLevel.Fatal, Compare);
            var isWarning = level.Equals(LogLevel.Warning, Compare);
            var isDebug = level.Equals(LogLevel.Debug, Compare);

            // log factory
            var message = logMessage.AsReadableString();
            if (isInfo)
            {
                System.Diagnostics.Trace.TraceInformation(message);
            }
            else if (isError)
            {
                System.Diagnostics.Trace.TraceError(message);
            }
            else if (isWarning)
            {
                System.Diagnostics.Trace.TraceWarning(message);
            }
            else if (isDebug)
            {
                System.Diagnostics.Trace.WriteLine(message);
            }
        }

        // setup trace listeners
        private void SetupTraceListener(string instanceName, string inDirectory)
        {
            // setup directory
            var directory = string.IsNullOrEmpty(inDirectory) || inDirectory.Equals(".")
                ? Environment.CurrentDirectory
                : inDirectory;

            // initialize listener
            Directory.CreateDirectory(directory);

            // setup conditions
            var exists = System.Diagnostics.Trace
                .Listeners
                .Cast<TraceListener>()
                .Any(l => l.Name.Equals(instanceName, Compare));
            if (exists)
            {
                return;
            }

            // setup trace
            var fileName = Path.Combine(directory, $"{instanceName}-{DateTime.Now:yyyyMMdd}.log");
            System.Diagnostics.Trace.AutoFlush = true;
            System.Diagnostics.Trace.Listeners.Add(new TextWriterTraceListener(fileName, name: instanceName));
        }
    }
}