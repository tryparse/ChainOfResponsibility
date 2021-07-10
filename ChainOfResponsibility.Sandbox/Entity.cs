using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace ChainOfResponsibility.Sandbox
{
    class Entity : IValidatableObject
    {
        [Required]
        public int? ID { get; set; }

        [StringLength(10)]
        public string FirstName { get; set; }
        
        [StringLength(10)]
        public string LastName { get; set; }
        
        public DateTime? CreatedDate { get; set; }
        
        public decimal? Amount { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (CreatedDate.HasValue
                && (CreatedDate.Value < SqlDateTime.MinValue.Value || CreatedDate.Value > SqlDateTime.MaxValue.Value))
            {
                errors.Add(new ValidationResult($"Date value should be from {SqlDateTime.MinValue.Value} to {SqlDateTime.MaxValue.Value}", new string[] { nameof(CreatedDate) }));
            }

            return errors;
        }
    }
}
