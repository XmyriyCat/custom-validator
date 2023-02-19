using Validator.Contracts;
using Validator.Implementation;
using Validator.Validators;

namespace Validator.Extensions
{
    public static class StandardValidatorExtension
    {
        public static IPropertyRule<T, TProperty> NotNull<T, TProperty>(this IPropertyRule<T, TProperty> rule)
        {
            var validator = new NotNullValidator<T, TProperty>();

            var component = new PropertyComponent<T, TProperty>(validator);

            var result = rule.AddPropertyComponent(component);

            return result;
        }

        public static IPropertyRule<T, string> Length<T>(this IPropertyRule<T, string> rule, int min, int max)
        {
            var validator = new LengthValidator<T, string>(min, max);

            var component = new PropertyComponent<T, string>(validator);

            var result = rule.AddPropertyComponent(component);

            return result;
        }

        public static IPropertyRule<T, TProperty> GreaterThan<T, TProperty>(this IPropertyRule<T, TProperty> rule, TProperty value) where TProperty : IComparable<TProperty>, IComparable
        {
            var validator = new GreaterThanValidator<T, TProperty>(value);

            var component = new PropertyComponent<T, TProperty>(validator);

            var result = rule.AddPropertyComponent(component);

            return result;
        }

        public static IPropertyRule<T, TProperty> GreaterThanOrEqual<T, TProperty>(this IPropertyRule<T, TProperty> rule, TProperty value) where TProperty : IComparable<TProperty>, IComparable
        {
            var validator = new GreaterThanOrEqualValidator<T, TProperty>(value);

            var component = new PropertyComponent<T, TProperty>(validator);

            var result = rule.AddPropertyComponent(component);

            return result;
        }
    }
}
