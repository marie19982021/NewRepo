using System;
using Xunit;

namespace PLEUnitTesting
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }
        [Fact]
        public void Test2()
        {
            int i = 0;

            i++;
            Assert.True(i == 1);
        }
    }
}
