/*
 * CHANGE LOG - keep only last 5 threads
 */
using Gravity.Abstraction.Logging.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gravity.Abstraction.Logging
{
    /// <summary>
    /// Base class for all ILogger implementations.
    /// </summary>
    public abstract class Logger : ILogger
    {
        // members: state
        private readonly string loggerName;      // logger name, will be under loggerName field
        private readonly string applicationName; // application name, will be under applicationName
        private string logLevel;                 // holds the current log level        

        /// <summary>
        /// Creates a new <see cref="Logger"/> instance.
        /// </summary>
        /// <param name="applicationName">Application under logging.</param>
        /// <param name="loggerName">Logger name.</param>
        protected Logger(string applicationName, string loggerName)
        {
            // set logger state
            this.loggerName = loggerName;
            this.applicationName = applicationName;

            // set log level
            SetLogLevel();
        }

        /// <summary>
        /// Gets the current log message (if any).
        /// </summary>
        public IDictionary<string, object> LogMessage { get; private set; }

        /// <summary>
        /// Gets or sets a value to activate console logging as well as current message logging.
        /// </summary>
        public bool LogOnConsole { get; set; }

        #region *** log levels         ***
        /// <summary>
        /// Gets or sets "Debug" level logging.
        /// "Debug" logging can be used anywhere you see fit and provided information which helps debugging
        /// your application.
        /// </summary>
        public bool IsDebugEnabled { get; set; }

        /// <summary>
        /// Gets or sets "Error" level logging.
        /// "Error" logging can be used on every "catch" block which does not terminate your application,
        /// but affects the application flow.
        /// </summary>
        public bool IsErrorEnabled { get; set; }

        /// <summary>
        /// Gets or sets "Fatal" level logging.
        /// "Fatal" logging can be used on every "catch" block which terminates your application.
        /// </summary>
        public bool IsFatalEnabled { get; set; }

        /// <summary>
        /// Gets or sets "Information" level logging.
        /// "Information" logging can be used whenever you want to let the user know that something happens.
        /// </summary>
        public bool IsInfoEnabled { get; set; }

        /// <summary>
        /// Gets or sets "Warning" level logging.
        /// "Warning" logging can be used whenever you want to let the user know that something happens,
        /// which can affect the application flow (like default values, retries missing information, etc.).
        /// </summary>
        public bool IsWarnEnabled { get; set; }

        /// <summary>
        /// Gets or sets "Trace" level logging.
        /// "Trace" logging can be used anywhere you see fit and provided any information about the
        /// application flow, not necessarily relevant or informative.
        /// </summary>
        public bool IsTraceEnabled { get; set; }
        #endregion

        #region *** log compliance     ***
        private bool DebugComliance => logLevel == null || IsDebugEnabled;
        private bool InfoCompliance => DebugComliance || IsInfoEnabled;
        private bool WarnComliance => InfoCompliance || IsWarnEnabled;
        private bool ErrorCompliance => WarnComliance || IsErrorEnabled;
        private bool FatalCompliance => ErrorCompliance || IsFatalEnabled;
        private bool TraceCompliance => IsTraceEnabled;
        #endregion

        /// <summary>
        /// Creates a new instance of <see cref="Logger"/>, with the same application name and a different logger name.
        /// </summary>
        /// <param name="loggerName">Logger name.</param>
        /// <returns>A new instance of <see cref="Logger"/>.</returns>
        public abstract ILogger CreateChildLogger(string loggerName);

        #region *** level: debug       ***
        /// <summary>
        /// Logs a "Debug" message with lazily constructed message. The message will be constructed
        /// only if the IsDebugEnabled is true.
        /// </summary>
        /// <param name="messageFactory">A delegate for creating a log message.</param>
        public void Debug(Func<string> messageFactory)
        {
            // exit conditions
            if (!DebugComliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Debug, message: messageFactory.Invoke());
        }

        /// <summary>
        /// Logs a "Debug" message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Debug(string message)
        {
            // exit conditions
            if (!DebugComliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Debug, message);
        }

        /// <summary>
        /// Logs a "Debug" message.
        /// </summary>
        /// <param name="message">The exception to log.</param>
        /// <param name="exception">The message to log.</param>
        public void Debug(string message, Exception exception)
        {
            // exit conditions
            if (!DebugComliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Debug, message, exception);
        }

        /// <summary>
        /// Logs a "Debug" message.
        /// </summary>
        /// <param name="formatProvider">The <see cref="IFormatProvider"/> to use.</param>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void DebugFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            // exit conditions
            if (!DebugComliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Debug, message: FormatMessage(formatProvider, format, args));
        }

        /// <summary>
        /// Logs a "Debug" message.
        /// </summary>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void DebugFormat(string format, params object[] args)
        {
            // exit conditions
            if (!DebugComliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Debug, message: FormatMessage(format, args));
        }

        /// <summary>
        /// Logs a "Debug" message.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void DebugFormat(Exception exception, string format, params object[] args)
        {
            // exit conditions
            if (!DebugComliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Debug, message: FormatMessage(format, args), exception);
        }

        /// <summary>
        /// Logs a "Debug" message.
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/> to log.</param>
        /// <param name="formatProvider">The <see cref="IFormatProvider"/> to use.</param>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void DebugFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
        {
            // exit conditions
            if (!DebugComliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Debug, message: FormatMessage(formatProvider, format, args), exception);
        }
        #endregion

        #region *** level: error       ***
        /// <summary>
        /// Logs an "Error" message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The <see cref="Exception"/> to log.</param>
        public void Error(string message, Exception exception)
        {
            // exit conditions
            if (!ErrorCompliance)
            {
                return;
            }
            // log entry
            Executor(level: LogLevel.Error, message, exception);
        }

        /// <summary>
        /// Logs an "Error" message with lazily constructed message. The message will be constructed
        /// only if the IsErrorEnabled is true.
        /// </summary>
        /// <param name="messageFactory">A delegate for creating a log message.</param>
        public void Error(Func<string> messageFactory)
        {
            // exit conditions
            if (!ErrorCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Error, message: messageFactory.Invoke());
        }

        /// <summary>
        /// Logs an "Error" message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Error(string message)
        {
            // exit conditions
            if (!ErrorCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Error, message);
        }

        /// <summary>
        /// Logs an "Error" message.
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/> to log.</param>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void ErrorFormat(Exception exception, string format, params object[] args)
        {
            // exit conditions
            if (!ErrorCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Error, message: FormatMessage(format, args), exception);
        }

        /// <summary>
        /// Logs an "Error" message.
        /// </summary>
        /// <param name="formatProvider">The <see cref="IFormatProvider"/> to use.</param>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            // exit conditions
            if (!ErrorCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Error, message: FormatMessage(formatProvider, format, args));
        }

        /// <summary>
        /// Logs an "Error" message.
        /// </summary>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void ErrorFormat(string format, params object[] args)
        {
            // exit conditions
            if (!ErrorCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Error, FormatMessage(format, args), null);
        }

        /// <summary>
        /// Logs an "Error" message.
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/> to log.</param>
        /// <param name="formatProvider">The <see cref="IFormatProvider"/> to use.</param>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void ErrorFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
        {
            // exit conditions
            if (!ErrorCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Error, message: FormatMessage(formatProvider, format, args));
        }
        #endregion

        #region *** level: fatal       ***
        /// <summary>
        /// Logs a "Fatal" message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Fatal(string message)
        {
            // exit conditions
            if (!FatalCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Fatal, message);
        }

        /// <summary>
        /// Logs a "Fatal" message with lazily constructed message. The message will be constructed
        /// only if the IsFatalEnabled is true.
        /// </summary>
        /// <param name="messageFactory">A delegate for creating a log message.</param>
        public void Fatal(Func<string> messageFactory)
        {
            // exit conditions
            if (!FatalCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Fatal, message: messageFactory.Invoke());
        }

        /// <summary>
        /// Logs a "Fatal" message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to log.</param>
        public void Fatal(string message, Exception exception)
        {
            // exit conditions
            if (!FatalCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Fatal, message, exception);
        }

        /// <summary>
        /// Logs a "Fatal" message.
        /// </summary>
        /// <param name="formatProvider">The <see cref="IFormatProvider"/> to use.</param>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void FatalFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            // exit conditions
            if (!FatalCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Fatal, message: FormatMessage(formatProvider, format, args));
        }

        /// <summary>
        /// Logs a "Fatal" message.
        /// </summary>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void FatalFormat(string format, params object[] args)
        {
            // exit conditions
            if (!FatalCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Fatal, message: FormatMessage(format, args));
        }

        /// <summary>
        /// Logs a "Fatal" message.
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/> to log.</param>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void FatalFormat(Exception exception, string format, params object[] args)
        {
            // exit conditions
            if (!FatalCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Fatal, message: FormatMessage(format, args), exception);
        }

        /// <summary>
        /// Logs a "Fatal" message.
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/> to log.</param>
        /// <param name="formatProvider">The <see cref="IFormatProvider"/> to use.</param>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void FatalFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
        {
            // exit conditions
            if (!FatalCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Fatal, message: FormatMessage(formatProvider, format, args), exception);
        }
        #endregion

        #region *** level: information ***
        /// <summary>
        /// Logs an "Information" message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The <see cref="Exception"/> to log.</param>
        public void Info(string message, Exception exception)
        {
            // exit conditions
            if (!IsInfoEnabled)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Information, message, exception);
        }

        /// <summary>
        /// Logs an "Information" message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Info(string message)
        {
            // exit conditions
            if (!InfoCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Information, message);
        }

        /// <summary>
        /// Logs an "Information" message with lazily constructed message. The message will be constructed
        /// only if the IsInfoEnabled is true.
        /// </summary>
        /// <param name="messageFactory">A delegate for creating a log message.</param>
        public void Info(Func<string> messageFactory)
        {
            // exit conditions
            if (!InfoCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Information, message: messageFactory.Invoke());
        }

        /// <summary>
        /// Logs an "Information" message.
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/> to log.</param>
        /// <param name="formatProvider">The <see cref="IFormatProvider"/> to use.</param>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void InfoFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
        {
            // exit conditions
            if (!InfoCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Information, message: FormatMessage(formatProvider, format, args), exception);
        }

        /// <summary>
        /// Logs an "Information" message.
        /// </summary>
        /// <param name="formatProvider">The <see cref="IFormatProvider"/> to use.</param>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void InfoFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            // exit conditions
            if (!InfoCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Information, message: FormatMessage(formatProvider, format, args));
        }

        /// <summary>
        /// Logs an "Information" message.
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/> to log.</param>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void InfoFormat(Exception exception, string format, params object[] args)
        {
            // exit conditions
            if (!InfoCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Information, message: FormatMessage(format, args), exception);
        }

        /// <summary>
        /// Logs an "Information" message.
        /// </summary>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void InfoFormat(string format, params object[] args)
        {
            // exit conditions
            if (!InfoCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Information, message: FormatMessage(format, args));
        }
        #endregion

        #region *** level: warning     ***
        /// <summary>
        /// Logs a "Warning" message with lazily constructed message. The message will be constructed
        /// only if the IsWarnEnabled is true.
        /// </summary>
        /// <param name="messageFactory">A delegate for creating a log message.</param>
        public void Warn(Func<string> messageFactory)
        {
            // exit conditions
            if (!WarnComliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Warning, message: messageFactory.Invoke());
        }

        /// <summary>
        /// Logs a "Warning" message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to log.</param>
        public void Warn(string message, Exception exception)
        {
            // exit conditions
            if (!WarnComliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Warning, message, exception);
        }

        /// <summary>
        /// Logs a "Warning" message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Warn(string message)
        {
            // exit conditions
            if (!WarnComliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Warning, message);
        }

        /// <summary>
        /// Logs a "Warning" message.
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/> to log.</param>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void WarnFormat(Exception exception, string format, params object[] args)
        {
            // exit conditions
            if (!WarnComliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Warning, message: FormatMessage(format, args), exception);
        }

        /// <summary>
        /// Logs a "Warning" message.
        /// </summary>
        /// <param name="formatProvider">The <see cref="IFormatProvider"/> to use.</param>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void WarnFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            // exit conditions
            if (!WarnComliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Warning, message: FormatMessage(formatProvider, format, args));
        }

        /// <summary>
        /// Logs a "Warning" message.
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/> to log.</param>
        /// <param name="formatProvider">The <see cref="IFormatProvider"/> to use.</param>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void WarnFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
        {
            // exit conditions
            if (!WarnComliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Warning, message: FormatMessage(formatProvider, format, args), exception);
        }

        /// <summary>
        /// Logs a "Warning" message.
        /// </summary>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void WarnFormat(string format, params object[] args)
        {
            // exit conditions
            if (!WarnComliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Warning, message: FormatMessage(format, args));
        }
        #endregion

        #region *** level: trace       ***
        /// <summary>
        /// Logs a "Trace" message with lazily constructed message. The message will be constructed
        /// only if the IsTraceEnabled is true.
        /// </summary>
        /// <param name="messageFactory">A delegate for creating a log message.</param>
        public void Trace(Func<string> messageFactory)
        {
            // exit conditions
            if (!TraceCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Trace, message: messageFactory.Invoke());
        }

        /// <summary>
        /// Logs a "Trace" message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to log.</param>
        public void Trace(string message, Exception exception)
        {
            // exit conditions
            if (!TraceCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Trace, message, exception);
        }

        /// <summary>
        /// Logs a "Trace" message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Trace(string message)
        {
            // exit conditions
            if (!TraceCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Trace, message);
        }

        /// <summary>
        /// Logs a "Trace" message.
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/> to log.</param>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void TraceFormat(Exception exception, string format, params object[] args)
        {
            // exit conditions
            if (!TraceCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Trace, message: FormatMessage(format, args), exception);
        }

        /// <summary>
        /// Logs a "Trace" message.
        /// </summary>
        /// <param name="formatProvider">The <see cref="IFormatProvider"/> to use.</param>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void TraceFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            // exit conditions
            if (!TraceCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Trace, message: FormatMessage(formatProvider, format, args));
        }

        /// <summary>
        /// Logs a "Trace" message.
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/> to log.</param>
        /// <param name="formatProvider">The <see cref="IFormatProvider"/> to use.</param>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void TraceFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
        {
            // exit conditions
            if (!TraceCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Trace, message: FormatMessage(formatProvider, format, args), exception);
        }

        /// <summary>
        /// Logs a "Trace" message.
        /// </summary>
        /// <param name="format">Format string for the message to log.</param>
        /// <param name="args">Format arguments for the message to log.</param>
        public void TraceFormat(string format, params object[] args)
        {
            // exit conditions
            if (!TraceCompliance)
            {
                return;
            }

            // log entry
            Executor(level: LogLevel.Trace, message: FormatMessage(format, args));
        }
        #endregion

        #region *** log executing      ***
        /// <summary>
        /// Executes a single log request against this <see cref="Logger"/>.
        /// </summary>
        /// <param name="level">Log level.</param>
        /// <param name="logMessage">Message to log.</param>
        public virtual void OnExecutor(string level, IDictionary<string, object> logMessage)
        {
            // Take no action
        }

        // logging pipeline execution
        private void Executor(string level, string message, Exception exception = null)
        {
            // setup
            LogMessage = GetLogEntry(level, message, exception);

            // write each line to the current standard output or error
            if (LogOnConsole)
            {
                ConsoleLogger(logMessage: LogMessage);
            }

            // plugin
            OnExecutor(level, LogMessage);
        }

        // create log entry to pass with http executor
        private IDictionary<string, object> GetLogEntry(string level, string message, Exception exception)
        {
            return exception == null
                ? GetObj(level, message)
                : GetExceptionObj(level, message, exception);
        }

        private IDictionary<string, object> GetObj(string level, string message) => DoGetObj(level, message);

        private IDictionary<string, object> GetExceptionObj(string level, string message, Exception exception)
        {
            // setup
            var obj = DoGetObj(level, message);
            obj["Exception"] = exception;

            // results
            return obj;
        }

        private IDictionary<string, object> DoGetObj(string level, string message) => new Dictionary<string, object>
        {
            ["Application"] = applicationName,
            ["Logger"] = loggerName,
            ["Message"] = message,
            ["TimeStamp"] = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff"),
            ["LogLevel"] = level,
            ["MachineName"] = Environment.MachineName
        };

        private void ConsoleLogger(IDictionary<string, object> logMessage)
        {
            // constants
            const StringComparison COMPARE = StringComparison.OrdinalIgnoreCase;

            // setup conditions
            var isError = $"{logMessage["LogLevel"]}".Equals(LogLevel.Error, COMPARE);
            var isFatal = $"{logMessage["LogLevel"]}".Equals(LogLevel.Fatal, COMPARE);

            // write to console
            if (isError || isFatal)
            {
                Console.Error.WriteLine(logMessage.AsReadableString());
            }
            else
            {
                Console.WriteLine(logMessage.AsReadableString());
            }
        }
        #endregion

        #region *** log settings       ***
        /// <summary>
        /// Implements a logic routine to get log level based on available <see cref="LogLevel"/>.
        /// </summary>
        /// <returns>Available <see cref="LogLevel"/>.</returns>
        public virtual string OnSetLogLevel()
        {
            return LogLevel.Debug;
        }

        // set current instance log level
        private void SetLogLevel()
        {
            // plugin
            logLevel = OnSetLogLevel();

            // exit conditions
            if (string.IsNullOrEmpty(logLevel))
            {
                UpdateAll(false);
                return;
            }

            // normalize logLevel
            logLevel = logLevel.ToUpper();

            // exit conditions
            if (logLevel.Equals("ALL", StringComparison.OrdinalIgnoreCase))
            {
                UpdateAll(true);
                return;
            }

            // get all log level properties
            var properties = GetLogLevels();

            // get property
            var property = properties.FirstOrDefault(p => p.Name.ToUpper().Contains(logLevel));

            // exit conditions
            if (property == null) return;

            // enable log level
            property.SetValue(this, true);

            // disable all log levels
            foreach (var level in properties.Where(p => !p.Name.ToUpper().Contains(logLevel)))
            {
                level.SetValue(this, false);
            }
        }

        // enable all properties
        private void UpdateAll(bool state)
        {
            foreach (var level in GetLogLevels())
            {
                level.SetValue(this, state);
            }
        }

        // get all log levels properties
        private IEnumerable<PropertyInfo> GetLogLevels() => GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(p => p.PropertyType == typeof(bool));
        #endregion

        #region *** message handlers   ***
        // try format a string, return exception stack if failed
        private string FormatMessage(string format, params object[] args)
        {
            try
            {
                return string.Format(format, args);
            }
            catch (Exception e) when (e != null)
            {
                return $"{e}";
            }
        }

        // try format a string, return exception stack if failed
        private string FormatMessage(IFormatProvider formatProvider, string format, params object[] args)
        {
            try
            {
                return string.Format(formatProvider, format, args);
            }
            catch (Exception e) when (e != null)
            {
                return $"{e}";
            }
        }
        #endregion
    }
}