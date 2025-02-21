using FluentAssertions;
using Xunit;

namespace FluentAssertion
{
    public class StringUnitTest
    {
        [Fact]
        public void Test()
        {
            #region testing String
            //testing String

            string notNullString = "this is my string";
            string? nullString = null;
            string emptyString = String.Empty;
            string whiteSpaceString = "                       ";

            ///dans xunit on a tjr assertion puis la methode qu'on utilise suivie de la chaine 
            ///attendue(expected) puis de la chaine reelle qu'on fourni(actual)
            Assert.Equal("this is my string", notNullString);

            //avec fluentAssertion c'est bcp plus lisible
            notNullString.Should().Be("this is my string");

            Assert.Equal("this is my string", notNullString, true);//specified ignore case
            notNullString.Should().BeEquivalentTo("this is my string");

            //verifier si le string est null
            Assert.Null(nullString);
            nullString.Should().BeNull(because: "a null string is always null");//ecriture des commantaires

            //verifier si la chaine est vide
            Assert.Empty(emptyString);
            emptyString.Should().BeEmpty();

            //verifier que la chaine n'est pas vide
            Assert.NotEmpty(notNullString);
            notNullString.Should().NotBeEmpty();

            //verifier la longueur du champs
            Assert.Equal(17,notNullString.Length);
            notNullString.Should().HaveLength(17);

            //verifier si la chaine contient une valeur recherche
            Assert.Contains("is my",notNullString);
            notNullString.Should().Contain("is my",because:"reasons");//donner des feedbacks aux devs

            //verifier le contenu exact de la chaine
            Assert.Contains("is mY sTRing", notNullString,StringComparison.InvariantCultureIgnoreCase);
            notNullString.Should().ContainEquivalentOf("is mY sTRing");

            notNullString.Should().Contain("is my",Exactly.Once());//specifier a quelle frequence cela doit se produire

            //verifier que des expressions sont vraies
            Assert.True(string.IsNullOrWhiteSpace(nullString));
            Assert.True(string.IsNullOrWhiteSpace(whiteSpaceString));
            Assert.True(string.IsNullOrWhiteSpace(emptyString));

            nullString.Should().BeNullOrWhiteSpace();
            whiteSpaceString.Should().BeNullOrWhiteSpace();
            emptyString.Should().BeNullOrWhiteSpace();

            //verifier que des expressions sont fausses
            Assert.False(string.IsNullOrWhiteSpace(notNullString));
            notNullString.Should().NotBeNullOrWhiteSpace();

            #endregion
        }
    }
}
  