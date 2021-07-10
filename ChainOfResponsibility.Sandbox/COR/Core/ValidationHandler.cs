using System;
using ChainOfResponsibility.Sandbox.Validation;

namespace ChainOfResponsibility.Sandbox.COR.Core
{
    public class ValidationHandler<TRequest, TValidated> : Handler<TRequest>, IHandler<TRequest> where TRequest: class
    {
        protected readonly IValidator<TValidated> _validator;

        public ValidationHandler(IValidator<TValidated> validator)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }
    }
}
