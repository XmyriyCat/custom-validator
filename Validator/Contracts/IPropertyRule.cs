using System.Linq.Expressions;

namespace Validator.Contracts
{
    public interface IPropertyRule<in T>
    {
        MemberExpression MemberExpression { get; }

        void ValidateComponents (T item);
    }

    public interface IPropertyRule<T, out TProperty> : IPropertyRule<T>
    {
        IPropertyRule<T, TProperty> AddPropertyComponent(IPropertyComponent<T, TProperty> item);
    }
}
