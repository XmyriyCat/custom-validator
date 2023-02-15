using System.Linq.Expressions;
using Validator.Contracts;

namespace Validator.Implementation
{
    public abstract class AbstractValidator<T> : IValidator<T>
    {


        public void AddValidationRule<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            // TODO Check nullable expression
        }

        public ValidationResult Validate(T item)
        {
            // TODO Implement this method!
            throw new NotImplementedException();
        }

        public void ValidateAndThrow(T item)
        {
            // TODO Implement this method!
            throw new NotImplementedException();
        }
    }
}
