/*
 * CHANGE LOG - keep only last 5 threads
 */
namespace Gravity.Abstraction.Logging
{
    /// <summary>
    /// A list of all available log levels used by <see cref="Logger"/>.
    /// </summary>
    public static class LogLevel
    {
        /// <summary>
        /// Constant value for "Debug" logging level.
        /// </summary>
        public const string Debug = "DEBUG";

        /// <summary>
        /// Constant value for "Information" logging level.
        /// </summary>
        public const string Information = "INFO";

        /// <summary>
        /// Constant value for "Warning" logging level.
        /// </summary>
        public const string Warning = "WARN";

        /// <summary>
        /// Constant value for "Error" logging level.
        /// </summary>
        public const string Error = "ERROR";

        /// <summary>
        /// Constant value for "Fatal" logging level.
        /// </summary>
        public const string Fatal = "FATAL";

        /// <summary>
        /// Constant value for "Trace" logging level.
        /// </summary>
        public const string Trace = "TRACE";
    }
}