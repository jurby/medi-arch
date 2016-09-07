using Mediware.Utils.Globalization;
using NUnit.Framework;

namespace Mediware.Utils.Tests
{
    [TestFixture]
    public class ByteSize
    {
        [OneTimeSetUp]
        public void SetUp()
        {
        }

        [TestCase(0, ExpectedResult = "0 b")]
        [TestCase(1, ExpectedResult = "1 B")]
        [TestCase(1000, ExpectedResult = "1000 B")]
        [TestCase(1024, ExpectedResult = "1 KB")]
        [TestCase(1572864, ExpectedResult = "1.5 MB")]
        [TestCase(-1000, ExpectedResult = "-1000 B")]
        [TestCase(int.MaxValue, ExpectedResult = "2 GB")]
        [TestCase(int.MinValue, ExpectedResult = "-2 GB")]
        [TestCase(long.MaxValue, ExpectedResult = "8388608 TB")]
        [TestCase(long.MinValue, ExpectedResult = "-8388608 TB")]
        public string Format_byte_size(long size)
        {
            using (new LanguageSwitchContext("en-US"))
            {
                return Format.ByteSizeHumanize(size);
            }
        }

        [Test]
        public void Is_Bool()
        {
            Assert.IsFalse(false);
        }
    }
}
