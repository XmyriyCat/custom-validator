﻿using Validator.Contracts;
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
    }
}