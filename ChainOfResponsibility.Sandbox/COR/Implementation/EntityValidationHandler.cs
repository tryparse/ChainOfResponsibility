using System;
using System.Linq;
using ChainOfResponsibility.Sandbox.COR.Core;
using ChainOfResponsibility.Sandbox.Entities;
using ChainOfResponsibility.Sandbox.Validation;

namespace ChainOfResponsibility.Sandbox.COR.Implementation
{
    public class EntityValidationHandler : ValidationHandler<ParserContext<FileData, Entity, DatabaseModel>, Entity>
    {
        public EntityValidationHandler(IValidator<Entity> validator) : base(validator)
        {
        }

        public override void Handle(ParserContext<FileData, Entity, DatabaseModel> context)
        {
            if (context.EntityMappingResult.Entity != null)
            {
                context.EntityValidationResult = _validator.Validate(context.EntityMappingResult.Entity);

                if (!context.EntityValidationResult.IsValid)
                {
                    context.ParserWarnings.AddRange(context.EntityValidationResult.Errors
                        .Select(x => new ParserWarning
                    {
                        FieldName = x.MemberNames.FirstOrDefault(),
                        Message = x.ErrorMessage,
                        IsCritical = x.ErrorMessage.Contains("required")
                    }));
                }

                base.Handle(context);
            }
            else
            {

            }
        }
    }
}
