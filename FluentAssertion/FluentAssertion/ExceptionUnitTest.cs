using FluentAssertions;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertion
{
    public class ExceptionUnitTest
    {

        [Fact]
        public void Test1()
        {
            //2methodes basees sur l'implementation d'action
            //methode1: declaration de l'action en premier (parfait pour la methodologie arrange , act and assert)
              // creation du SUT : sujet sous test/subject under test

            var sut = new TestableClass();//arrange

            var act = () => sut.ShouldThrowException();//act

            act.Should().Throw<Exception>();//assert

            //methode2: pas besoin de declarer l'action au prealable
            //ecriture du test en 1e ligne 

            sut.Invoking(x => x.ShouldThrowException())
                .Should().Throw<Exception>()
                //le ? permet de specifie que le message correspond aumoins a  1 caractere dans cette possition
                //l'* correspont a 0 ou plusieurs caracteres dans cette possition
                //.WithMessage("throw");
                //.WithMessage("?hrow");
                //.WithMessage("*w");
                //where permet de mettre une expressiom lamda
                .Where(t => t.Message.Contains("thr"));

            //conotation negative : lorque quil y a pas d'exception
            sut.Invoking(x => x.ShouldNotThrowException())
                .Should()
                .NotThrow<NotImplementedException>();

        }

        public class TestableClass
        {
            public void ShouldThrowException()
            {
                throw new Exception("throw");
            }
            public void ShouldNotThrowException()
            {
                if(1 == 2)
                {
                    throw new NotImplementedException();
                }
                throw new NullReferenceException("L'objet est null !");

            }
        }
    }
}
