using System.Linq;
using ChainOfResponsibility.Sandbox.COR.Core;
using ChainOfResponsibility.Sandbox.Mapping;

namespace ChainOfResponsibility.Sandbox.COR.Implementation
{
    public class FileDataToEntityMappingHandler : MappingHandler<ParserContext<FileData, Entity, DatabaseModel>, FileData, Entity>
    {
        public FileDataToEntityMappingHandler(IMapper<FileData, Entity> mapper) : base(mapper)
        {
        }

        public new void Handle(ParserContext<FileData, Entity, DatabaseModel> request)
        {
            if (request.FileData != null)
            {
                request.EntityMappingResult = _mapper.Map(request.FileData);

                if (!request.EntityMappingResult.IsMapped)
                {
                    request.ParserWarnings.AddRange(request.EntityMappingResult.Errors.Select(x => new ParserWarning
                    {
                        FieldName = x.FieldName,
                        FieldValue = x.FieldValue,
                        Message = x.Message
                    }));
                }

                base.Handle(request);
            }
            else
            {

            }
        }
    }
}
