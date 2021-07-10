using System;
using System.Collections.Generic;
using System.Linq;
using ChainOfResponsibility.Sandbox.COR.Core;
using ChainOfResponsibility.Sandbox.COR.Implementation;
using ChainOfResponsibility.Sandbox.Mapping;
using ChainOfResponsibility.Sandbox.Validation;

namespace ChainOfResponsibility.Sandbox.Runners
{
    class CORRunner : IRunner
    {
        private readonly IMapper<FileData, Entity> _fileDataToEntityMapper;
        private readonly IMapper<Entity, DatabaseModel> _entityToDatabaseModelMapper;
        private readonly IValidator<Entity> _entityValidator;
        private readonly IValidator<DatabaseModel> _databaseModelValidator;

        public CORRunner(
            IMapper<FileData, Entity> fileDataToEntityMapper,
            IMapper<Entity, DatabaseModel> entityToDatabaseModelMapper,
            IValidator<Entity> entityValidator,
            IValidator<DatabaseModel> databaseModelValidator)
        {
            _fileDataToEntityMapper = fileDataToEntityMapper;
            _entityToDatabaseModelMapper = entityToDatabaseModelMapper;
            _entityValidator = entityValidator;
            _databaseModelValidator = databaseModelValidator;
        }

        public void Run()
        {
            var fileData = new FileData()
            {
                Fields = new List<string>
                {
                    "1",
                    "FirstName",
                    "LastName",
                    "1991-07-25",
                    "30"
                }
            };

            var request = new ParserContext<FileData, Entity, DatabaseModel>(fileData);

            var handler = new FileDataToEntityMappingHandler(_fileDataToEntityMapper);

            handler
                .SetNext(new EntityValidationHandler(_entityValidator))
                .SetNext(new EntityToDatabaseModelMappingHandler(_entityToDatabaseModelMapper))
                .SetNext(new DatabaseModelValidationHandler(_databaseModelValidator))
                .SetNext(new ParsingFinishHandler());

            handler.Handle(request);

            Console.WriteLine($"IsSuccessed={request.IsSuccessed}");
            Console.WriteLine(string.Join("; ", request.ParserWarnings.Select(x => x.ToString())));
        }
    }
}
