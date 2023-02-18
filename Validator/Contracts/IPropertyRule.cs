using System.Linq.Expressions;
using Validator.Implementation;

namespace Validator.Contracts
{
    public interface IPropertyRule<in T>
    {
        MemberExpression MemberExpression { get; }

        ValidationPropertyResult ValidateComponents (T item);
    }

    public interface IPropertyRule<T, out TProperty> : IPropertyRule<T>
    {
        IPropertyRule<T, TProperty> AddPropertyComponent(IPropertyComponent<T, TProperty> item);
    }
}
