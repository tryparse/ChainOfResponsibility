using System.Data.SqlTypes;
using ChainOfResponsibility.Sandbox.Entities;
using FluentValidation;

namespace ChainOfResponsibility.Sandbox.Validation
{
    public class EntityValidator : AbstractValidator<Entity>
    {
        public EntityValidator()
        {
            RuleFor(x => x.ID).NotNull();
            RuleFor(x => x.FirstName).MaximumLength(10);
            RuleFor(x => x.LastName).MaximumLength(10);
            RuleFor(x => x.BirthDate).InclusiveBetween(SqlDateTime.MinValue.Value, SqlDateTime.MaxValue.Value);
        }
    }
}
