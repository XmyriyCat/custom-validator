using BusinessLogic.Models;
using BusinessLogic.Validators;
using Validator.Exceptions;
using Xunit;

namespace ValidatorTests
{
    public class StandardValidatorTests
    {
        [Fact]
        public void NotNull_WhenUserNameIsNull_ShouldThrowValidationException()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Name = null,
                Age = 19
            };

            var userValidator = new UserValidator();

            // Act && Assert
            Assert.Throws<ValidationException>(() => userValidator.ValidateAndThrow(user));
        }

        [Fact]
        public void NotNull_WhenUserNameIsNull_ShouldReturnNegativeResult()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Name = null,
                Age = 19
            };
            
            var userValidator = new UserValidator();

            // Act
            var validationResult = userValidator.Validate(user);

            // Assert
            Assert.NotNull(validationResult);
            Assert.NotNull(validationResult.Errors);
            Assert.Single(validationResult.Errors);
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void Length_WhenStringIsLargerThanMax_ShouldThrowValidationException()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Name = "asdaasdaasdaasdaasdaasdaasdaasdaasdaasdaasda46",
                Age = 19
            };

            var userValidator = new UserValidator();

            // Act && Assert
            Assert.Throws<ValidationException>(() => userValidator.ValidateAndThrow(user));
        }
    }
}