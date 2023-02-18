using Validator.Contracts;
using Validator.Implementation;

namespace Validator.Validators
{
    public class NotNullValidator<T, TProperty> : IPropertyValidator<T, TProperty>
    {
        public ValidationComponentResult Validate(TProperty value)
        {
            if (value is not null)
            {
                // return successful ValidationComponentResult without errors.
                return new ValidationComponentResult();
            }

            var componentError = new ValidationComponentError("Source value is null");

            var validationError = new ValidationComponentResult(componentError);

            return validationError;
        }
    }
}
