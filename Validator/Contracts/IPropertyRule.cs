using System.Linq.Expressions;

namespace Validator.Contracts
{
    public interface IPropertyRule<T>
    {
        MemberExpression MemberExpression { get; }
    }

    public interface IPropertyRule<T, out TProperty> : IPropertyRule<T>
    {
        IPropertyRule<T, TProperty> AddPropertyComponent(IPropertyComponent<T, TProperty> item);
    }
}
