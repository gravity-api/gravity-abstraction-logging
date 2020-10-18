/*
 * CHANGE LOG - keep only last 5 threads
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gravity.Abstraction.Logging.Extensions
{
    /// <summary>
    /// Extensions package for ILogger.
    /// </summary>
    public static class LoggerExtensions
    {
        /// <summary>
        /// Converts a log message into a readable text message that can printed or saved to a file.
        /// </summary>
        /// <param name="logMessage">Log message to convert.</param>
        /// <returns>Readable <see cref="string"/> when can posted to console or into a file.</returns>
        public static string AsReadableString(this IDictionary<string, object> logMessage)
        {
            // constants
            const string Application = "Application";
            const string Logger = "Logger";
            const string LogLevel = "LogLevel";
            const string TimeStamp = "TimeStamp";
            const string MachineName = "MachineName";
            const string Exception = "Exception";

            // black list
            var blackList = new[] { Application, Logger, LogLevel, TimeStamp, MachineName, Exception };

            // get string length
            var keys = logMessage.Keys.ToArray();
            var maxLength = keys.Max(i => i.Length);

            // exclude exception
            var pairs = logMessage.Where(i => !blackList.Contains(i.Key));

            // build: setup
            var level = GetLevel($"{logMessage[LogLevel]}");
            var log = new StringBuilder($"{level} - {logMessage[TimeStamp]}{Environment.NewLine}");
            AppendDefaults(logMessage, maxLength, log);

            // build: iterate
            foreach (var pair in pairs)
            {
                var indent = GetIndent(key: pair.Key, maxLength);
                var message = $"{pair.Value}".Replace(Environment.NewLine, string.Empty);
                log.Append("    ").Append(pair.Key).Append(indent).Append(": ").AppendLine(message);
            }

            // exception handler
            return logMessage.ContainsKey(Exception)
                ? AppendExceptionEntry(logMessage, log).ToString()
                : log.ToString();
        }

        private static string GetLevel(string level) => level.ToUpper() switch
        {
            LogLevel.Debug => "DBG",
            LogLevel.Error => "ERR",
            LogLevel.Fatal => "FTL",
            LogLevel.Information => "INF",
            LogLevel.Trace => "TRC",
            LogLevel.Warning => "WRN",
            _ => "TRC"
        };

        private static void AppendDefaults(IDictionary<string, object> logMessage, int maxLength, StringBuilder log)
        {
            // constants
            const string Application = "Application";
            const string Logger = "Logger";
            const string LogLevel = "LogLevel";
            const string TimeStamp = "TimeStamp";
            const string MachineName = "MachineName";

            // defaults
            if (logMessage.ContainsKey(Application))
            {
                AppendKey(logMessage, maxLength, key: Application, log);
            }
            if (logMessage.ContainsKey(Logger))
            {
                AppendKey(logMessage, maxLength, key: Logger, log);
            }
            if (logMessage.ContainsKey(LogLevel))
            {
                AppendKey(logMessage, maxLength, key: LogLevel, log);
            }
            if (logMessage.ContainsKey(TimeStamp))
            {
                AppendKey(logMessage, maxLength, key: TimeStamp, log);
            }
            if (logMessage.ContainsKey(MachineName))
            {
                AppendKey(logMessage, maxLength, key: MachineName, log);
            }
        }

        private static void AppendKey(IDictionary<string, object> logMessage, int maxLength, string key, StringBuilder log)
        {
            log
                .Append("    ")
                .Append(key)
                .Append(GetIndent(key, maxLength))
                .Append(": ")
                .Append(logMessage[key])
                .AppendLine();
        }

        private static string GetIndent(string key, int maxLength)
        {
            // get indent for entry
            var indent = maxLength - key.Length;

            // results
            return new string(' ', indent);
        }

        private static StringBuilder AppendExceptionEntry(IDictionary<string, object> logMessage, StringBuilder log)
        {
            return log
                .AppendLine("----------------")
                .AppendLine("- Exception(s) -")
                .AppendLine("----------------")
                .Append(logMessage["Exception"]).AppendLine();
        }
    }
}