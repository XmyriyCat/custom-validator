using Validator.Implementation;

namespace Validator.Contracts
{
    public interface IPropertyComponent<T, in TProperty>
    {
        ValidationResult InvokePropertyValidator(TProperty value);
    }
}
