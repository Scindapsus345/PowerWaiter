using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PowerWaiters.Extensions;

namespace PowerWaitersTests
{
    [TestFixture]
    class IntExTests
    {
        [TestCase(10, "10 ₽")]
        [TestCase(10000, "10 000 ₽")]
        [TestCase(1000000, "1 000 000 ₽")]
        public void ToCurrencyTests(int number, string expectedString)
        {
            Assert.AreEqual(number.ToCurrencyString(), expectedString);
        }


        [TestCase(10, "10 XP")]
        [TestCase(10000, "10 000 XP")]
        [TestCase(1000000, "1 000 000 XP")]
        public void ToXPTests(int number, string expectedString)
        {
            Assert.AreEqual(number.ToXPString(), expectedString);
        }

        [TestCase(10, "10")]
        [TestCase(10000, "10 000")]
        [TestCase(1000000, "1 000 000")]
        public void ToFriendlyTests(int number, string expectedString)
        {
            Assert.AreEqual(number.ToFriendlyString(), expectedString);
        }
    }
}
