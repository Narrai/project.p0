using PizzaWorld.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
    public class UserTest
    {
        [Fact] // in xnit (attribute)
        private void Test_OrderExists()
        {
            // arrange
            var sut = new User();

            // act
            var actual = sut;

            // assert
            Assert.IsType<User>(actual);
            Assert.NotNull(actual);

        }
    }
}