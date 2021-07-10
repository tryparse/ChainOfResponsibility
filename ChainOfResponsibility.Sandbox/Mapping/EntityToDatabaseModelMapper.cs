using System.Collections.Generic;
using ChainOfResponsibility.Sandbox.COR.Implementation;
using ChainOfResponsibility.Sandbox.Entities;

namespace ChainOfResponsibility.Sandbox.Mapping
{
    class EntityToDatabaseModelMapper : IMapper<Entity, DatabaseModel>
    {
        public IMappingResult<DatabaseModel> Map(Entity sourceEntity)
        {
            var errors = new List<ParserWarning>();
            var resultEntity = new DatabaseModel();

            resultEntity.ID = sourceEntity.ID;
            resultEntity.FullName = $"{sourceEntity.FirstName} {sourceEntity.LastName}";
            resultEntity.BirthDate = sourceEntity.BirthDate;
            resultEntity.Age = sourceEntity.Age;

            return new MappingResult<DatabaseModel>
            {
                Entity = resultEntity,
                Errors = errors
            };
        }
    }
}
