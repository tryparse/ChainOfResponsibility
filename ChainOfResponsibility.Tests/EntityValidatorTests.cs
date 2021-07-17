using ChainOfResponsibility.Sandbox.Entities;
using ChainOfResponsibility.Sandbox.Validation;
using FluentValidation;
using FluentValidation.TestHelper;
using NUnit.Framework;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ChainOfResponsibility.Tests
{
    [TestFixture]
    public class EntityValidatorTests
    {
        IValidator<Entity> _validator;

        [SetUp]
        public void Initialize()
        {
            _validator = new EntityValidator();
        }

        [Test]
        public void Empty_ID_Should_Be_Validated()
        {
            var entity = new Entity
            {
                ID = 1,
                FirstName = string.Empty,
                LastName = string.Empty,
                BirthDate = null,
                Amount = null
            };

            var result = _validator.TestValidate(entity);

            result.ShouldHaveValidationErrorFor(x => x.ID);
        }
    }

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
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}