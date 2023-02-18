using Validator.Implementation;

namespace Validator.Contracts
{
    public interface IPropertyValidator<T, in TProperty>
    {
        ValidationComponentResult Validate(TProperty value);
    }
}
