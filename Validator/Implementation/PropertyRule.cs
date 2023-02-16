using System.Linq.Expressions;
using Validator.Contracts;

namespace Validator.Implementation
{
    public class PropertyRule<T, TProperty> : IPropertyRule<T, TProperty>
    {
        public MemberExpression MemberExpression { get; }

        public IEnumerable<PropertyComponent<T, TProperty>> Components { get; set; } = new List<PropertyComponent<T, TProperty>>();

        public PropertyRule(MemberExpression memberExpression)
        {
            MemberExpression = memberExpression;
        }

        public IPropertyRule<T, TProperty> AddPropertyComponent(IPropertyComponent<T, TProperty> item)
        {
            Components.Append(item);

            return this;
        }
    }
}
