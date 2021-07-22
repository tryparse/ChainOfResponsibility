using FluentValidation.TestHelper;
using NUnit.Framework;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ChainOfResponsibility.Tests
{
    public static class FluentValidationTestExtensions
    {
        public static void ShouldHaveValidationErrorFor<TSource, TValue, TProperty>(
            this TestValidationResult<TSource, TValue> validationResult, 
            Expression<Func<TSource, TProperty>> expression) where TSource: class
        {
            var type = typeof(TSource);

            MemberExpression memberExpression = expression.Body as MemberExpression;
            PropertyInfo propertyInfo = memberExpression?.Member as PropertyInfo;

            if (!string.IsNullOrEmpty(propertyInfo.Name))
            {
                var property = type.GetProperty(propertyInfo.Name);

                if (!validationResult.Result.Errors.Any(x => x.PropertyName == propertyInfo.Name))
                {
                    throw new ValidationTestException($"{property.Name}");
                }
                else
                {
                    Assert.Pass($"'{property.Name}' was validated");
                }
            }
            else
            {
                throw new ArgumentException($"Can't find property '{propertyInfo.Name}'");
            }
        }
    }
}