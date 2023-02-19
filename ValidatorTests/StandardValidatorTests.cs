using BusinessLogic.Models;
using BusinessLogic.Validators;
using Validator.Exceptions;
using Xunit;

namespace ValidatorTests
{
    public class StandardValidatorTests
    {
        [Fact]
        public void ValidateAndThrow_WhenAllParamsIsValid_ShouldReturnOk()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Name = "Pavel",
                Age = 19
            };

            var userValidator = new UserValidator();

            // Act && Assert
            userValidator.ValidateAndThrow(user);
        }

        [Fact]
        public void Validate_WhenAllParamsIsValid_ShouldReturnOk()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Name = "Pavel",
                Age = 19
            };
            
            var userValidator = new UserValidator();

            // Act
            var validationResult = userValidator.Validate(user);

            // Assert
            Assert.NotNull(validationResult);
            Assert.NotNull(validationResult.Errors);
            Assert.Empty(validationResult.Errors);
            Assert.True(validationResult.IsValid);
        }
        
        [Fact]
        public void ValidateAndThrow_WhenUserNameIsNull_ShouldThrowValidationException()
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
        public void Validate_WhenUserNameIsNull_ShouldReturnNegativeResult()
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
        public void ValidateAndThrow_WhenNameIsLargerThanMax_ShouldThrowValidationException()
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

        [Fact]
        public void Validate_WhenNameIsLargerThanMax_ShouldReturnNegativeResult()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Name = "asdaasdaasdaasdaasdaasdaasdaasdaasdaasdaasda46",
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
        public void ValidateAndThrow_WhenIdIsEqualZero_ShouldThrowValidationException()
        {
            // Arrange
            var user = new User
            {
                Id = 0,
                Name = "Pavel",
                Age = 19
            };

            var userValidator = new UserValidator();

            // Act && Assert
            Assert.Throws<ValidationException>(() => userValidator.ValidateAndThrow(user));
        }

        [Fact]
        public void Validate_WhenIdIsEqualZero_ShouldReturnNegativeResult()
        {
            // Arrange
            var user = new User
            {
                Id = 0,
                Name = "Pavel",
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
        public void ValidateAndThrow_WhenAgeIsLessThan19_ShouldThrowValidationException()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Name = "Pavel",
                Age = 18
            };

            var userValidator = new UserValidator();

            // Act && Assert
            Assert.Throws<ValidationException>(() => userValidator.ValidateAndThrow(user));
        }

        [Fact]
        public void Validate_WhenAgeIsLessThan19_ShouldReturnNegativeResult()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Name = "Pavel",
                Age = 18
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
    }
}