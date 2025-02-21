using FluentAssertions;
using System.Reflection;
using Xunit;

namespace FluentAssertion
{
    public class AssemblyUnitTest
    {
        [Fact]
        public void Test1()
        {
            //chargement des assembly
            var core = Assembly.Load(nameof(Core));
            var data = Assembly.Load(nameof(DataLayer));
            var Business = Assembly.Load(nameof(BusinessLayer));

            //test des referencements 
            data.Should().Reference(core);
            data.Should().NotReference(Business);
            Business.Should().Reference(core);
            Business.Should().NotReference(data);


        }
    }
}
