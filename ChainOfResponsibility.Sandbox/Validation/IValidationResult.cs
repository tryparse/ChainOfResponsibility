using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChainOfResponsibility.Sandbox.Validation
{
    public interface IValidationResult
    {
        bool IsValid { get; }
        List<ValidationResult> Errors { get; }
    }
}
