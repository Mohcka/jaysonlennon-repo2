using System;
using System.Reflection;
using Xunit;
using System.Linq;


namespace TestAptMgmtPortal
{
    public class TestAPIUtil
    {
        [Fact]
        public void TestResourceProjections()
        {
            var usage = 15;
            var periodStart = new DateTime(2020, 1, 1);
            var periodEnd = new DateTime(2020, 1, 20);
            var now = new DateTime(2020, 1, 15);

            double projection = AptMgmtPortalAPI.Util.ResourceProjection
                .TotalForPeriod(usage, periodStart, periodEnd, now);

            Assert.Equal(20, projection);

        }
    }
}