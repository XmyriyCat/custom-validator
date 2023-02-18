using Validator.Contracts;

namespace Validator.Implementation
{
    public class PropertyComponent<T, TProperty> : IPropertyComponent<T, TProperty>
    {
        private readonly IPropertyValidator<T, TProperty> _propertyValidator;

        public PropertyComponent(IPropertyValidator<T, TProperty> propertyValidator)
        {
            _propertyValidator = propertyValidator;
        }

        public ValidationComponentResult InvokePropertyValidator(TProperty value)
        {
            var validationError = _propertyValidator.Validate(value);

            return validationError;
        }
    }
}
