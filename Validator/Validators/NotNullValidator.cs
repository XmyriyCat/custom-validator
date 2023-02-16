using Validator.Contracts;
using Validator.Implementation;

namespace Validator.Validators
{
    public class NotNullValidator<T, TProperty> : IPropertyValidator<T, TProperty>
    {
        public ValidationResult Validate(TProperty value)
        {
            if (value is not null)
            {
                // return successful ValidationResult without errors.
                return new ValidationResult();
            }

            var validationError = new ValidationError()
            {
                Message = "Source value is null"
            };

            var validationResult = new ValidationResult();

            validationResult.AddValidationError(validationError);

            return validationResult;
        }
    }
}
