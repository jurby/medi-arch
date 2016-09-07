using NUnit.Framework;
using Mediware.Util.Validation.Extensions;
using Mediware.Util.Validation.Helpers;

namespace Mediware.Util.Validation.Tests
{
    [TestFixture]
    public class PhoneNumberHelperTest
    {
        private const string ValidPhoneNumber = "+420776278045";
        private string SecondValidPhoneNumber { get; set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            SecondValidPhoneNumber = "776278045";
        }

        #region PhoneNumber helper

        [TestCase(ValidPhoneNumber, ExpectedResult = true)]
        [TestCase("+420 775 278 045", ExpectedResult = true)]
        [TestCase("775 278 445", ExpectedResult = true)]
        [TestCase("775 2780 45", ExpectedResult = false)]
        [TestCase("775 2780 a5", ExpectedResult = false)]
        public bool PhoneNumbersAreValid(string phoneNumber)
        {
            return PhoneNumberHelper.IsValidPhoneNumber(phoneNumber);
        }

        [Test]
        public void FirstValidPhoneNumberIsValid()
        {
            Assert.AreEqual(true, PhoneNumberHelper.IsValidPhoneNumber(ValidPhoneNumber));
        }

        [Test]
        public void SecondValidBankAccountNumberIsValid()
        {
            Assert.AreEqual(true, PhoneNumberHelper.IsValidPhoneNumber(SecondValidPhoneNumber));
        }

        #endregion

        #region String extensions

        [Test]
        public void ValidStringExtensionsForPhoneNumberAreValid()
        {
            Assert.IsTrue(ValidPhoneNumber.IsValidPhoneNumber());
        }

        #endregion
    }
}
