using PizzaWorld.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
    public class StoreTest
    {
        [Fact] // in xnit (attribute)
        private void Test_OrderExists()
        {
            // arrange
            var sut = new Store();

            // act
            var actual = sut;

            // assert
            Assert.IsType<Store>(actual);
            Assert.NotNull(actual);

        }
    }
}