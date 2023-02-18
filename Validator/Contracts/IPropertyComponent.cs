using Validator.Implementation;

namespace Validator.Contracts
{
    public interface IPropertyComponent<T, in TProperty>
    {
        ValidationComponentResult InvokePropertyValidator(TProperty value);
    }
}
