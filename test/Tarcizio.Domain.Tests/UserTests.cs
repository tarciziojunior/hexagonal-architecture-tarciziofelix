using Tarcizio.Domain.Users;
using Xunit;

namespace Tarcizio.Domain.Tests
{
    public class UserTests
    {
        [Fact]
        public void Null_Name_Should_Exception()
        {
            //
            // Arrange
            string empty = string.Empty;
            User user = new User
            {
                Name = empty
            };

            //
            // Act and Assert
            Assert.Throws<NullException>(
                () => user.NameMandatory());
        }

        [Fact]
        public void Null_Email_Should_Exception()
        {
            //
            // Arrange
            string empty = string.Empty;
            User user = new User
            {
                Email = empty
            };

            //
            // Act and Assert
            Assert.Throws<NullException>(
                () => user.EmailMandatory());
        }

        [Theory]
        [InlineData("08724050601")]
        [InlineData("545454")]
        [InlineData("212312")]
        [InlineData("27999994522")]
        [InlineData("42asdfgfga")]
        public void Many_Email_Should_Exception(string phone)
        {
            //
            // Arrange
            string empty = string.Empty;
            User user = new User
            {
                Phone = phone
            };

            //
            // Act and Assert
            Assert.Throws<InvalidPhoneException>(
                () => user.PhoneFormat());
        }

        [Theory]
        [InlineData("08724050601")]
        [InlineData("545454")]
        [InlineData("212312")]
        [InlineData("27999994522")]
        [InlineData("42asdfgfga")]
        [InlineData("(xx) xxxx-xxxx")]
        public void Many_Phone_Should_Exception(string phone)
        {
            //
            // Arrange
            string empty = string.Empty;
            User user = new User
            {
                Phone = phone
            };

            //
            // Act and Assert
            Assert.Throws<InvalidPhoneException>(
                () => user.PhoneFormat());
        }

        [Theory]
        [InlineData("(99) 09999-9999")]
        [InlineData("(99) 9999-9999")]
        [InlineData("")]
        public void Many_Phone_Should_Valid(string phone)
        {
            //
            // Arrange
            string empty = string.Empty;
            User user = new User
            {
                Phone = phone
            };

            //
            // Act and Assert
            user.PhoneFormat();
        }
    }
}
