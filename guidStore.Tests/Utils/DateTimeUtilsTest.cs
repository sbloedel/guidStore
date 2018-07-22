using Microsoft.VisualStudio.TestTools.UnitTesting;
using guidStore.Utils;
using System;

namespace guidStore.Tests.Utils
{
    [TestClass]
    public class DateTimeUtilsTest
    {
        [TestMethod]
        public void ShouldConvertEpochToDateTime()
        {
            var expected = new DateTime(2018, 8, 21, 11, 36, 47, DateTimeKind.Utc);
            var results = DateTimeUtils.EpochToDateTime(1534851407);
            Assert.AreEqual(expected, results);
        }

        [TestMethod]
        public void ShouldConvertDateTimeToEpoch()
        {
            var expected = 1534851407;
            var results = DateTimeUtils.DateTimeToEpoch(new DateTime(2018, 8, 21, 11, 36, 47, DateTimeKind.Utc));
            Assert.AreEqual(expected, results);
        }
    }
}