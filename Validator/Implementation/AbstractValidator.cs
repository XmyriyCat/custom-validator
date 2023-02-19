using System.Linq.Expressions;
using Validator.Contracts;
using Validator.Exceptions;

namespace Validator.Implementation
{
    public abstract class AbstractValidator<T> : IValidator<T>
    {
        private List<IPropertyRule<T>> _propertyRules = new List<IPropertyRule<T>>();

        protected IPropertyRule<T, TProperty> AddValidationRule<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            if (expression is null)
            {
                throw new ArgumentNullException($"{nameof(expression)} is null.");
            }

            var member = expression.Body as MemberExpression;

            if (member is null)
            {
                throw new ArgumentNullException($"MemberExpression {nameof(member)} is null.");
            }

            var rule = new PropertyRule<T, TProperty>(member);

            _propertyRules.Add(rule);

            return rule;
        }

        public ValidationResult Validate(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException($"{nameof(item)} is null.");
            }

            var validationResult = new ValidationResult();

            foreach (var rule in _propertyRules)
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
            var validationResult = Validate(item);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }
        }
    }
}
