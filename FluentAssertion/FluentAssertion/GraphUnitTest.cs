using FluentAssertions;
using Xunit;

namespace FluentAssertion
{
    public class GraphUnitTest
    {
        [Fact]
        public void Test1()
        {
            //Object graph comparison : evaluer 2 object en fonction de leur structure
            var test = new Test { Name = "Test", Value = "123" };
            var testDto = new TestDto { Name = "Test", Value = 123 };

            //Assert.Equal(testDto.Name, test.Name);
            //Assert.Equal(testDto.Value, test.Value);//ne compare que les meme type 
            //Assert.Equal(testDto, test);//imp de comparer deux objects

            //testDto.Should().BeEquivalentTo(test);
            //testDto.Should().BeEquivalentTo(test, options => options
            //.Excluding(t => t.Value));//permet d'exclure un champs lors de la comparaison

            //testDto.Should().BeEquivalentTo(test, options => options
            //.ExcludingMissingMembers()); //exclu les membres manauants

            //comparer un int et un string
            //testDto.Should().BeEquivalentTo(test,options => options
            //    .WithAutoConversionFor(t => t.Path.Contains("Value")));

            //convertion auto pour chaque object
            testDto.Should().BeEquivalentTo(test,options => options
                .WithAutoConversion());

            //autoriser l'infini recurcivite
            testDto.Should().BeEquivalentTo(test, options => options
                .AllowingInfiniteRecursion());
        }
    }
    public class Test
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class TestDto
    {
        public string Name { get; set; }
        //public string Value { get; set; }
        public int Value { get; set; }
    }
}
