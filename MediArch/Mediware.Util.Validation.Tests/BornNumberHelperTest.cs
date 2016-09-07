using System;
using Mediware.Util.Validation.Extensions;
using Mediware.Util.Validation.Helpers;
using NUnit.Framework;

namespace Mediware.Util.Validation.Tests
{
    [TestFixture]
    public class BornNumberHelperTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
        }

        #region Validace rodných čísel - první varianta

        [TestCase("890603/9120", ExpectedResult = true)]
        [TestCase("890603/0000", ExpectedResult = true)]
        [TestCase("490808/001", ExpectedResult = true)]
        [TestCase("890617/1234", ExpectedResult = false)]
        public bool BornNumbersAreValid(string bornNumber)
        {
            return BornNumberHelper.IsValidBornNumber(bornNumber);
        }

        #endregion

        #region Validace rodných čísel - druhá varianta
        [Test]
        public void ValidBornNumberIsValid()
        {
            const string bornNumber = "890603/9120";
            Assert.AreEqual(true, BornNumberHelper.IsValidBornNumber(bornNumber));
        }

        [Test]
        public void ValidBornNumberDateOnlyIsValid()
        {
            const string bornNumber = "890603/0000";
            Assert.AreEqual(true, BornNumberHelper.IsValidBornNumber(bornNumber));
        }

        [Test]
        public void OldBornNumberIsValid()
        {
            const string bornNumber = "490808/001";
            Assert.AreEqual(true, BornNumberHelper.IsValidBornNumber(bornNumber));
        }

        [Test]
        public void InvalidBornNumberIsInvalid()
        {
            const string bornNumber = "890617/1234";
            Assert.AreEqual(false, BornNumberHelper.IsValidBornNumber(bornNumber));
        }

        #endregion

        #region Validace rodných čísel - pohlaví

        [Test]
        public void BornNumberIsWomanWithManReturnsFalse()
        {
            const string bornNumber = "890617/1234";
            Assert.AreEqual(false, BornNumberHelper.IsWoman(bornNumber));
        }

        [Test]
        public void BornNumberIsWomanWithWomanReturnsTrue()
        {
            const string bornNumber = "895617/1234";
            Assert.AreEqual(true, BornNumberHelper.IsWoman(bornNumber));
        }

        [Test]
        public void BornNumberIsWomanThrowsWithInvalidNumber()
        {
            const string bornNumber = "asdasdsdfg";
            Assert.Throws<ArgumentException>(() => BornNumberHelper.IsWoman(bornNumber));
        }

        #endregion

        #region String extensions

        [Test]
        public void ValidStringExtensionsForBornNumberAreValid()
        {
            const string validBornNumber = "890603/9120";
            const string nonValidBornNumber = "890617/1234";

            Assert.IsTrue(validBornNumber.IsValidBornNumber());
            Assert.IsFalse(nonValidBornNumber.IsValidBornNumber());
        }

        #endregion
    }
}
