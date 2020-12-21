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
            var sut = new MeatPizza();

            // act
            var actual = sut;

            // assert
           Assert.IsType<MeatPizza>(actual);
            Assert.NotNull(actual);

        }
    }
}