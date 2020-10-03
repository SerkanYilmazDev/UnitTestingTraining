using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        [Test]
        public void Log_WhenSendErrorString_ExpectedLastErrorPropertIsNotEmpty()
        {
            var logger = new ErrorLogger();

            logger.Log("error");

            Assert.That(logger.LastError, Is.EqualTo("error"));
        }

        [Test]
        public void Log_WhenSendEmptyParameter_ThrowArgumentNullException()
        {
            var logger = new ErrorLogger();

            Assert.That(() => logger.Log(""), Throws.ArgumentNullException);
        }
    }
}