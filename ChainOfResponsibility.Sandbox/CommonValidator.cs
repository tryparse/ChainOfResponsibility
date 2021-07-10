using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Sandbox
{
    class CommonValidator<T> : IValidator<T> where T : class
    {
        public bool Validate(T entity, out List<ValidationResult> errors)
        {
            var validationContext = new ValidationContext(entity);
            errors = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(entity, validationContext, errors);

            return isValid;
        }
    }

    interface IValidator<T> where T: class
    {
        bool Validate(T entity, out List<ValidationResult> errors);
    }
}
