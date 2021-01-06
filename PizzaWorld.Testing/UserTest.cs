using PizzaWorld.Domain.Models;
using Xunit;
using PizzaWorld.Client;

namespace PizzaWorld.Testing
{
    public class UserTest
    {
        private static readonly SqlClient _sql = new SqlClient();
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

        [Fact]
        public void UserExist()
        {
            //  Assert.True(_sql.IsUserExist("Nar")); passed
             Assert.True(_sql.IsUserExist("Ruk")); // failed 

            
        }
    }
}