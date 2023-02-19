using Validator.Contracts;
using Validator.Implementation;

namespace Validator.Validators
{
    public class LengthValidator<T, TProperty> : IPropertyValidator<T, string>
    {
        public LengthValidator(int minLength, int maxLength)
        {
            if (minLength < 0)
            {
                throw new ArgumentException("Min length of string should be more than zero.");
            }

            if (minLength > maxLength)
            {
                throw new ArgumentException("Max length should be greater than Min");
            }

            MinLength = minLength;
            MaxLength = maxLength;
        }

        public int MinLength { get;}
        public int MaxLength { get; }

        public ValidationComponentResult Validate(string value)
        {
            var validationResult = new ValidationComponentResult();

            if (value is null)
            {
                return validationResult;
            }
            
            var valueLength = value.Length;
            
            if (!InRange(valueLength))
            {
                var validationError = new ValidationComponentError($"{value.GetType()} length value is not in range [{MinLength}..{MaxLength}]. Actual Length is {valueLength}.");
                validationResult.Error = validationError;
            }

            return validationResult;
        }

        private bool InRange(int number)
        {
            return MinLength <= number && number <= MaxLength;
        }
    }
}
