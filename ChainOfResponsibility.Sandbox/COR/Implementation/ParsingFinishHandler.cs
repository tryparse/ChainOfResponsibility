using ChainOfResponsibility.Sandbox.COR.Core;
using ChainOfResponsibility.Sandbox.Entities;

namespace ChainOfResponsibility.Sandbox.COR.Implementation
{
    class ParsingFinishHandler :
        Handler<ParserContext<FileData, Entity, DatabaseModel>>,
        IHandler<ParserContext<FileData, Entity, DatabaseModel>>
    {
        public override void Handle(ParserContext<FileData, Entity, DatabaseModel> context)
        {
            if (context.DataBaseModelMappingResult != null
                && context.DataBaseModelMappingResult.IsMapped
                && context.DatabaseModelValidationResult != null
                && context.DatabaseModelValidationResult.IsValid)
            {
                context.IsSuccessed = true;
            }

            base.Handle(context);
        }
    }
}
