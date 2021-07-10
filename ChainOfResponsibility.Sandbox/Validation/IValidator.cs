using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChainOfResponsibility.Sandbox.Validation
{
    public interface IValidator<T>
    {
        IValidationResult Validate(T entity);
    }
}
