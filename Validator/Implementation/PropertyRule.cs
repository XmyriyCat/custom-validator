using System.Linq.Expressions;
using System.Reflection;
using Validator.Contracts;

namespace Validator.Implementation
{
    public class PropertyRule<T, TProperty> : IPropertyRule<T, TProperty>
    {
        public MemberExpression MemberExpression { get; }

        private List<IPropertyComponent<T, TProperty>> _components = new List<IPropertyComponent<T, TProperty>>();

        public PropertyRule(MemberExpression memberExpression)
        {
            MemberExpression = memberExpression;
        }

        public IPropertyRule<T, TProperty> AddPropertyComponent(IPropertyComponent<T, TProperty> item)
        {
            _components.Add(item);

            return this;
        }

        public ValidationPropertyResult ValidateComponents(T item)
        {
            var property = MemberExpression.Member as PropertyInfo;

            if (property is null)
            {
                throw new ArgumentNullException($"{typeof(PropertyInfo)} {nameof(property)} is null" );
            }

            var propertyValueObj = property.GetValue(item);

            var propertyValue = (TProperty)propertyValueObj;

            var validationPropertyResult = new ValidationPropertyResult();

            foreach (var component in _components)
            {
                var componentResult = component.InvokePropertyValidator(propertyValue);

                if (!componentResult.IsValid)
                {
                    validationPropertyResult.AddValidationComponentResult(componentResult);
                }
            }

            return validationPropertyResult;
        }
    }
}
