using Validator.Contracts;

namespace Validator.Implementation
{
    public class RuleContext<T, TPropery>
    {
        public IValidationRule<T, TPropery> Rules;
    }
}
