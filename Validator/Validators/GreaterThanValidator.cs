using Validator.Contracts;
using Validator.Implementation;

namespace Validator.Validators
{
    public class GreaterThanValidator<T, TProperty> : IPropertyValidator<T, TProperty> where TProperty : IComparable<TProperty>, IComparable
    {
        public GreaterThanValidator(TProperty value)
        {
            Value = value;
        }

        public TProperty Value { get; }

        public ValidationComponentResult Validate(TProperty value)
        {
            var validationResult = new ValidationComponentResult();

            if (value is null)
            {
                return validationResult;
            }

            // If method CompareTo(TProperty item) returns 1 then param value is greater prop Value.
            var isGreater = value.CompareTo(Value) > 0;

            if (!isGreater)
            {
                var validationError = new ValidationComponentError($"The source value {Value} is less than {value}");
                validationResult.Error = validationError;
            }

            return validationResult;
        }
    }
}
