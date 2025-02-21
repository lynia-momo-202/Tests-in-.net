using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace FluentAssertion
{
    public class AssertionScopes
    {
        [Fact]
        public void Test1()
        {
            var people = new Person().Get();

            using (new AssertionScope())//permet de poursuivre les tests meme apres une erreur
            {

                people.Should().NotBeNullOrEmpty();
                people.Should().ContainEquivalentOf(new Person { Name = "john", Age = 31 }); //ce test echou et les tests qui le suivent ne sont pas excecute
                people.Should().HaveCount(5);
                people.Should().OnlyHaveUniqueItems();

            }

        }

        public class Person
        {
            public Person()
            {

            }
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
            public string Name { get; set; }
            public int Age { get; set; }
            public List<Person> Get()
            {
                return new List<Person>
                {
                    new("John",30),
                    new("Thomas",40),
                    new("Elizabeth",60),
                };
            }

        }
    }
}
