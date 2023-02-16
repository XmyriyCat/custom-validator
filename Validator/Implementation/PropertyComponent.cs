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

        public ValidationResult InvokePropertyValidator(TProperty value)
        {
            var validationResult = _propertyValidator.Validate(value);

            return validationResult;
        }
    }
}
