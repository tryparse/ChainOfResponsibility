using System;
using System.Collections.Generic;
using System.Globalization;
using ChainOfResponsibility.Sandbox.COR.Implementation;

namespace ChainOfResponsibility.Sandbox.Mapping
{
    public class FileDataToEntityMapper : IMapper<FileData, Entity>
    {
        public IMappingResult<Entity> Map(FileData sourceEntity)
        {
            var mappingErrors = new List<ParserWarning>();
            var resultEntity = new Entity();

            try
            {
                if (int.TryParse(sourceEntity.Fields[0], out var id))
                {
                    resultEntity.ID = id;
                }
                else
                {
                    mappingErrors.Add(new ParserWarning
                    {
                        FieldName = nameof(resultEntity.ID),
                        FieldValue = sourceEntity.Fields[0],
                        Message = "Can't map"
                    });
                }

                resultEntity.FirstName = sourceEntity.Fields[1];
                resultEntity.LastName = sourceEntity.Fields[2];
                
                if (DateTime.TryParseExact(sourceEntity.Fields[3], "yyyy-MM-dd", null, DateTimeStyles.None, out var birthDate))
                {
                    resultEntity.BirthDate = birthDate;
                }
                else
                {
                    mappingErrors.Add(new ParserWarning
                    {
                        FieldName = nameof(resultEntity.BirthDate),
                        FieldValue = sourceEntity.Fields[3],
                        Message = $"Can't map. Expected format is yyyy-MM-dd"
                    });
                }

                if (int.TryParse(sourceEntity.Fields[4], out var age))
                {
                    resultEntity.Age = age;
                }
                else
                {
                    mappingErrors.Add(new ParserWarning
                    {
                        FieldName = nameof(resultEntity.BirthDate),
                        FieldValue = sourceEntity.Fields[4],
                        Message = $"Can't map"
                    });
                }
            }
            catch (Exception ex)
            {
                mappingErrors.Add(new ParserWarning
                {
                    Message = ex.Message
                });
            }

            return new MappingResult<Entity>
            {
                Entity = resultEntity,
                Errors = mappingErrors
            };
        }
    }
}
