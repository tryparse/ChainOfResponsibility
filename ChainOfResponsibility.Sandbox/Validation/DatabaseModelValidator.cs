using System.Data.SqlTypes;
using ChainOfResponsibility.Sandbox.Entities;
using FluentValidation;

namespace ChainOfResponsibility.Sandbox.Validation
{
    public class DatabaseModelValidator : AbstractValidator<DatabaseModel>
    {
        public DatabaseModelValidator()
        {
            RuleFor(x => x.ID)
                .NotNull();
            RuleFor(x => x.FullName)
                .MaximumLength(30);
            RuleFor(x => x.BirthDate)
                .InclusiveBetween(SqlDateTime.MinValue.Value, SqlDateTime.MaxValue.Value)
                .WithErrorCode("EMAIL");
            RuleFor(x => x.Amount)
                .ScalePrecision(10, 2);
        }
    }
}
