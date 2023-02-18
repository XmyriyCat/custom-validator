using System.Linq.Expressions;
using System.Reflection;
using Validator.Contracts;

namespace Validator.Implementation
{
    public class PropertyRule<T, TProperty> : IPropertyRule<T, TProperty>
    {
        public MemberExpression MemberExpression { get; }

        public List<IPropertyComponent<T, TProperty>> Components { get; set; } = new List<IPropertyComponent<T, TProperty>>();

        public PropertyRule(MemberExpression memberExpression)
        {
            MemberExpression = memberExpression;
        }

        public IPropertyRule<T, TProperty> AddPropertyComponent(IPropertyComponent<T, TProperty> item)
        {
            Components.Add(item);

            return this;
        }

        public ValidationPropertyResult ValidateComponents(T item)
        {
            var property = MemberExpression.Member as PropertyInfo;

            if (property is null)
            {
                // TODO Create new Exception class!
                throw new NotImplementedException("Create new Exception");
            }

            var propertyValueObj = property.GetValue(item);

            var propertyValue = (TProperty)propertyValueObj;

            var validationPropertyResult = new ValidationPropertyResult();

            foreach (var component in Components)
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
