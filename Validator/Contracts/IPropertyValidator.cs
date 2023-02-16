using Validator.Implementation;

namespace Validator.Contracts
{
    public interface IPropertyValidator<T, in TProperty>
    {
        ValidationResult Validate(TProperty value);
    }
}
