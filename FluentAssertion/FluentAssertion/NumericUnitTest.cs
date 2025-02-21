using FluentAssertions;
using Xunit;

namespace FluentAssertion
{
    public class NumericUnitTest
    {
        [Fact]
        public void IntTest()
        {
            //certaines fonctions de test pour les stings sont aussi valable pour les types numerique(be,notbe,...)
            #region Numeric types

            //test des signes (positivite)
            int positive = 1;
            int negative = -1;
             
            
            positive.Should().BePositive();
            negative.Should().BeNegative();

            positive.Should().BeGreaterThan(0);
            positive.Should().BeLessThan(5);
            negative.Should().BeLessThan(0);

            positive.Should().BeGreaterThanOrEqualTo(1);
            positive.Should().BeLessThanOrEqualTo(1);

            positive.Should().BeInRange(0,2);
            positive.Should().NotBeInRange(2,3);
             
            #endregion
            
        }

        [Fact]
        public void FloatTest()
        {
            //les nombre a virgule floatante sont bizarre et inexacte ce qui rand les tests diffice pour l'ordi
            //ils possedent donc leur propre fonction de test 

            #region weird floating point value
            double i = 4.35 * 100;
            //i.Should().Be(435);//that's wrong??
            i.Should().BeApproximately(435, 0.1);
            
            #endregion
        }
    }
}
