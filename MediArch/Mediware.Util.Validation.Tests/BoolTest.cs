using NUnit.Framework;

namespace Mediware.Util.Validation.Tests
{
    [TestFixture]
    public class BoolTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Is_Bool()
        {
            Assert.IsFalse(false);
        }
    }
}
