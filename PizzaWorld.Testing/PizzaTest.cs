using PizzaWorld.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
    public class PizzaTest
    {
        [Fact] // in xnit (attribute)
        private void Test_OrderExists()
        {
            // arrange
            var sut = new Pizza();

            // act
            var actual = sut;

            // assert
           Assert.IsType<Pizza>(actual);
            Assert.NotNull(actual);

        }
    }
}