using System.Linq;
using ChainOfResponsibility.Sandbox.COR.Core;
using ChainOfResponsibility.Sandbox.Entities;
using ChainOfResponsibility.Sandbox.Validation;

namespace ChainOfResponsibility.Sandbox.COR.Implementation
{
    class DatabaseModelValidationHandler : ValidationHandler<ParserContext<FileData, Entity, DatabaseModel>, DatabaseModel>
    {
        public DatabaseModelValidationHandler(IValidator<DatabaseModel> validator) : base(validator)
        {
        }

        public override void Handle(ParserContext<FileData, Entity, DatabaseModel> context)
        {
            if (context.DataBaseModelMappingResult != null)
            {
                 context.DatabaseModelValidationResult = _validator.Validate(context.DataBaseModelMappingResult.Entity);

                if (!context.DatabaseModelValidationResult.IsValid)
                {
                    context.ParserWarnings.AddRange(context.DatabaseModelValidationResult.Errors
                        .Select(x => new ParserWarning
                    {
                        FieldName = x.MemberNames.FirstOrDefault(),
                        Message = x.ErrorMessage,
                        IsCritical = x.ErrorMessage.Contains("required")
                    }));
                }

                base.Handle(context);
            }
        }
    }
}
