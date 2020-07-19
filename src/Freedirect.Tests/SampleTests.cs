using Xunit;

namespace Freedirect.Tests
{
    public class SampleTests
    {
        [Fact]
        public void Test_Passing()
        {
            Assert.True(true);
        }

        [Fact]
        public void Test_Failing()
        {
            Assert.True(false);
        }
    }
}