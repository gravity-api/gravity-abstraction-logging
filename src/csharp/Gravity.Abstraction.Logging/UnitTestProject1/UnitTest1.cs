using Gravity.Abstraction.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var logger = new TraceLogger("test_application", "test_logger");
            logger.LogOnConsole = true;
            logger.Info("test message on main logger");
            logger.CreateChildLogger("child_test_logger").Warn("test warning on child logger");

            try
            {
                throw new ArgumentOutOfRangeException("test exception");
            }
            catch (System.Exception e)
            {
                logger.Fatal(e.Message, e);
            }
            try
            {
                throw new ArgumentOutOfRangeException("test exception");
            }
            catch (System.Exception e)
            {
                logger.Fatal(e.Message, e);
            }
            try
            {
                throw new ArgumentOutOfRangeException("test exception");
            }
            catch (System.Exception e)
            {
                logger.Fatal(e.Message, e);
            }
        }
    }
}
