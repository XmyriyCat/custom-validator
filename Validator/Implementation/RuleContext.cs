using Validator.Contracts;

namespace Validator.Implementation
{
    public class RuleContext<T, TProperty>
    {
        public IValidationRule<T, TProperty> Rules;
    }
}
