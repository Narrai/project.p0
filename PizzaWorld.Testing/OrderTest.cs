using PizzaWorld.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
    public class OrderTest
    {
        [Fact] // in xnit (attribute)
        private void Test_OrderExists()
        {
            // arrange
            var sut = new Order();

            // act
            var actual = sut;

            // assert
            Assert.IsType<Order>(actual);
            Assert.NotNull(actual);

        }
    }
}