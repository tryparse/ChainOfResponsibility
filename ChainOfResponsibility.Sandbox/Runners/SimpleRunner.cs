using System;
using System.Collections.Generic;
using System.Linq;
using ChainOfResponsibility.Sandbox.Entities;
using ChainOfResponsibility.Sandbox.Mapping;
using ChainOfResponsibility.Sandbox.Validation;
using FluentValidation;

namespace ChainOfResponsibility.Sandbox.Runners
{
    public class SimpleRunner : IRunner
    {
        private readonly IMapper<FileData, Entity> _fileDataToEntityMapper;
        private readonly IMapper<Entity, DatabaseModel> _entityToDatabaseModelMapper;
        private readonly IValidator<Entity> _entityValidator;
        private readonly IValidator<DatabaseModel> _databaseModelValidator;

        public SimpleRunner(IMapper<FileData, Entity> fileDataToEntityMapper, IMapper<Entity, DatabaseModel> entityToDatabaseModelMapper, IValidator<Entity> entityValidator, IValidator<DatabaseModel> databaseModelValidator)
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

            var entityMappingResults = _fileDataToEntityMapper.Map(fileData);

            if (entityMappingResults.IsMapped)
            {
                var entityValidationResult = _entityValidator.Validate(entityMappingResults.Entity);

                if (!entityValidationResult.IsValid)
                {
                    Console.WriteLine(string.Join("; ", entityValidationResult.Errors.Select(x => x.ToString())));
                }

                var databaseModelMappingResult = _entityToDatabaseModelMapper.Map(entityMappingResults.Entity);

                if (databaseModelMappingResult.IsMapped)
                {
                    var databaseModelValidationResult = _databaseModelValidator.Validate(databaseModelMappingResult.Entity);

                    if (!databaseModelValidationResult.IsValid)
                    {
                        Console.WriteLine(string.Join("; ", databaseModelValidationResult.Errors.Select(x => x.ToString())));
                    }

                    Console.WriteLine($"Success! *** {databaseModelMappingResult.Entity}");
                }
            }
            else
            {
                Console.WriteLine(string.Join("; ", entityMappingResults.Errors.Select(x => x.ToString())));
            }
        }
    }
}
