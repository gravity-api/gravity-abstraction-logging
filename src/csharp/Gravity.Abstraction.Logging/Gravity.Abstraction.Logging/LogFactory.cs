/*
 * CHANGE LOG - keep only last 5 threads
 */
using System;

namespace Gravity.Abstraction.Logging
{
    public static class LogFactory
    {
        /// <summary>
        /// Creates a new <see cref="Logger"/> instance.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="Logger"/> to create.</typeparam>
        /// <param name="applicationName">Application name.</param>
        /// <param name="loggerName">Logger name.</param>
        /// <returns>An <see cref="ILogger"/> interface representing your <see cref="Logger"/> type.</returns>
        public static ILogger Create<T>(string applicationName, string loggerName) where T : ILogger
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { applicationName, loggerName });
        }

        /// <summary>
        /// Creates a new <see cref="Logger"/> instance.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="Logger"/> to create.</typeparam>
        /// <param name="args"><see cref="Logger"/> constructor parameters.</param>
        /// <returns>An <see cref="ILogger"/> interface representing your <see cref="Logger"/> type.</returns>
        public static ILogger Create<T>(params object[] args) where T : ILogger
        {
            return (T)Activator.CreateInstance(typeof(T), args);
        }
    }
}
