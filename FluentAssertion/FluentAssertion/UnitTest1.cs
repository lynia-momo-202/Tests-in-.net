using FluentAssertions;
using Xunit;

namespace FluentAssertion
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            #region installation  et verification

            var x = "value";
            x.Should().Be("value");

            #endregion
        }
    }
}
  