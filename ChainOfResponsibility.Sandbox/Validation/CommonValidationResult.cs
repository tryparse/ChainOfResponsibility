using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChainOfResponsibility.Sandbox.Validation
{
    public class CommonValidationResult : IValidationResult
    {
        public bool IsValid { get; set; }

        public List<ValidationResult> Errors { get; set; }
    }
}
