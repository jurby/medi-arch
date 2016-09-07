using NUnit.Framework;
using Mediware.Util.Validation.Extensions;
using Mediware.Util.Validation.Helpers;

namespace Mediware.Util.Validation.Tests
{
    [TestFixture]
    public class BankAccountNumberHelperTest
    {
        private const string ValidBankAccountNumber = "34278-0727558021/0100";
        private string SecondValidBankAccountNumber { get; set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            SecondValidBankAccountNumber = "19-2000145399/0800";
        }

        #region Bank Account Number helper

        [TestCase(ValidBankAccountNumber, ExpectedResult = true)]
        [TestCase("19-2000145399/0800", ExpectedResult = true)]
        [TestCase("178124-4159/0710", ExpectedResult = true)]
        [TestCase("890617/1234", ExpectedResult = false)]
        public bool BankAccountNumbersAreValid(string bornNumber)
        {
            return BankAccountNumberHelper.IsValidBankAccountNumber(bornNumber);
        }

        [Test]
        public void FirstValidBankAccountNumberIsValid()
        {
            Assert.AreEqual(true, BankAccountNumberHelper.IsValidBankAccountNumber(ValidBankAccountNumber));
        }

        [Test]
        public void SecondValidBankAccountNumberIsValid()
        {
            Assert.AreEqual(true, BankAccountNumberHelper.IsValidBankAccountNumber(SecondValidBankAccountNumber));
        }

        #endregion

        #region String extensions

        [Test]
        public void ValidStringExtensionsForBankAccountNumberAreValid()
        {
            Assert.IsTrue(ValidBankAccountNumber.IsValidBankAccountNumber());
        }

        #endregion
    }
}
