using Validator.Implementation;

namespace Validator.Contracts
{
    public interface IValidator<in T>
    {
        ValidationResult Validate(T item);

        void ValidateAndThrow(T item);
    }
}