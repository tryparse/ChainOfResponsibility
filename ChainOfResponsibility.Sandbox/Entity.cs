using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace ChainOfResponsibility.Sandbox
{
    public class Entity : IValidatableObject
    {
        [Required]
        public int? ID { get; set; }

        [StringLength(10)]
        public string FirstName { get; set; }
        
        [StringLength(10)]
        public string LastName { get; set; }
        
        public DateTime? BirthDate { get; set; }
        
        public int? Age { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (BirthDate.HasValue
                && (BirthDate.Value < SqlDateTime.MinValue.Value || BirthDate.Value > SqlDateTime.MaxValue.Value))
            {
                errors.Add(new ValidationResult($"Date value should be from {SqlDateTime.MinValue.Value} to {SqlDateTime.MaxValue.Value}", new string[] { nameof(BirthDate) }));
            }

            return errors;
        }
    }
}
