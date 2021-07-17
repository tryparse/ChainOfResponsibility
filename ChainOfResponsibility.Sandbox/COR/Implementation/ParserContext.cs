using System.Collections.Generic;
using ChainOfResponsibility.Sandbox.Mapping;
using ChainOfResponsibility.Sandbox.Validation;
using FluentValidation.Results;

namespace ChainOfResponsibility.Sandbox.COR.Implementation
{
    public class ParserContext<RawDataType, EntityType, DataBaseModelType>
    {
        public RawDataType FileData { get; set; }
        public IMappingResult<EntityType> EntityMappingResult { get; set; }
        public ValidationResult EntityValidationResult { get; set; }
        public IMappingResult<DataBaseModelType> DataBaseModelMappingResult { get; set; }
        public ValidationResult DatabaseModelValidationResult { get; set; }
        public List<ParserWarning> ParserWarnings { get; set; } = new List<ParserWarning>();
        public bool IsSuccessed { get; set; }

        public ParserContext(RawDataType fileData)
        {
            FileData = fileData;
        }
    }
}
