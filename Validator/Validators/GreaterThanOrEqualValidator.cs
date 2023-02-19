using Validator.Contracts;
using Validator.Implementation;

namespace Validator.Validators
{
    public class GreaterThanOrEqualValidator<T, TProperty> : IPropertyValidator<T, TProperty> where TProperty : IComparable<TProperty>, IComparable
    {
        public GreaterThanOrEqualValidator(TProperty value)
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

            var isGreaterOrEqual = value.CompareTo(Value) >= 0;

            if (!isGreaterOrEqual)
            {
                var validationError = new ValidationComponentError($"The source value {Value} is less than {value}");
                validationResult.Error = validationError;
            }

            return validationResult;
        }
    }
}
