using ChainOfResponsibility.Sandbox.COR.Core;
using ChainOfResponsibility.Sandbox.Entities;
using ChainOfResponsibility.Sandbox.Mapping;

namespace ChainOfResponsibility.Sandbox.COR.Implementation
{
    public class EntityToDatabaseModelMappingHandler : MappingHandler<ParserContext<FileData, Entity, DatabaseModel>, Entity, DatabaseModel>
    {
        public EntityToDatabaseModelMappingHandler(IMapper<Entity, DatabaseModel> mapper) : base(mapper)
        {
        }

        public override void Handle(ParserContext<FileData, Entity, DatabaseModel> request)
        {
            if (request.EntityMappingResult != null)
            {
                if (request.EntityMappingResult.IsMapped)
                {
                    request.DataBaseModelMappingResult = _mapper.Map(request.EntityMappingResult.Entity);
                }

                base.Handle(request);
            }
            else
            {

            }
        }
    }
}
