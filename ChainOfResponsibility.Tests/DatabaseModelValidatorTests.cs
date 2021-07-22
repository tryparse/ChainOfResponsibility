using ChainOfResponsibility.Sandbox.Entities;
using ChainOfResponsibility.Sandbox.Validation;
using FluentValidation;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace ChainOfResponsibility.Tests
{
    [TestFixture]
    public class DatabaseModelValidatorTests
    {
        private IValidator<DatabaseModel> _validator;

        [SetUp]
        public void Initialize()
        {
            _validator = new DatabaseModelValidator();
            ValidatorOptions.LanguageManager.Enabled = false;
        }

        [Test]
        public void Too_Precise_Amount_Should_Be_Validated()
        {
            var databaseModel = new DatabaseModel
            {
                ID = 0,
                Amount = 10.999m
            };

            var result = _validator.TestValidate(databaseModel);

            result.ShouldHaveValidationErrorFor(x => x.Amount);
        }
    }
}
