using System.Linq.Expressions;
using Validator.Contracts;

namespace Validator.Implementation
{
    public abstract class AbstractValidator<T> : IValidator<T>
    {
        public List<IPropertyRule<T>> PropertyRules = new List<IPropertyRule<T>>();

        public IPropertyRule<T, TProperty> AddValidationRule<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            // TODO Check nullable expression

            var member = expression.Body as MemberExpression;

            if (member is null)
            {
                // TODO Create new Exception class!
                throw new NotImplementedException("Create new Exception");
            }

            var rule = new PropertyRule<T, TProperty>(member);

            PropertyRules.Add(rule);
            
            return rule;
        }

        public ValidationResult Validate(T item)
        {
            var validationResult = new ValidationResult();

            foreach (var rule in PropertyRules)
            {
                var validationPropertyResult = rule.ValidateComponents(item);

                if (!validationPropertyResult.IsValid)
                {
                    validationResult.AddValidationError(validationPropertyResult);
                }
            }

            return validationResult;
        }

        public void ValidateAndThrow(T item)
        {
            // TODO Implement this method!
            throw new NotImplementedException();
        }
    }
}
