using ChainOfResponsibility.Sandbox.Entities;
using ChainOfResponsibility.Sandbox.Validation;
using FluentValidation;
using FluentValidation.TestHelper;
using NUnit.Framework;

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
                ID = null,
                FirstName = string.Empty,
                LastName = string.Empty,
                BirthDate = null,
                Amount = null
            };

            var result = _validator.TestValidate(entity);

            result.ShouldHaveValidationErrorFor(x => x.ID);
        }

        [Test]
        public void Too_Long_FirstName_Should_Be_Validated()
        {
            var entity = new Entity
            {
                ID = 0,
                FirstName = "123456789012345",
                LastName = string.Empty,
                BirthDate = null,
                Amount = null
            };

            var result = _validator.TestValidate(entity);

            result.ShouldHaveValidationErrorFor(x => x.FirstName);
        }

        [Test]
        public void Too_Long_LastName_Should_Be_Validated()
        {
            var entity = new Entity
            {
                ID = 0,
                FirstName = string.Empty,
                LastName = "123456789012345",
                BirthDate = null,
                Amount = null
            };

            var result = _validator.TestValidate(entity);

            result.ShouldHaveValidationErrorFor(x => x.LastName);
        }
    }
}