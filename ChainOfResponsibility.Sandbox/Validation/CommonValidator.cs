using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChainOfResponsibility.Sandbox.Validation
{
    public class CommonValidator<T> : IValidator<T> where T : class
    {
        public IValidationResult Validate(T entity)
        {
            var validationContext = new ValidationContext(entity);
            var errors = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(entity, validationContext, errors);

            return new CommonValidationResult
            {
                IsValid = isValid,
                Errors = errors
            };
        }
    }
}
