using System.Reflection;
using System;
using Xunit;

using AptMgmtPortal;

namespace TestApi
{
    public class UnitTest1
    {
        [Fact]
        public void FailingTest()
        {
            Assert.True(false);
        }

        [Fact]
        public void PassingTest()
        {
            Assert.True(true);
        }

        [Fact]
        public void Coverage()
        {
            var someClass = new WeatherForecast();
            someClass.Summary = "nothing";
            Assert.True(true);
        }
    }
}
