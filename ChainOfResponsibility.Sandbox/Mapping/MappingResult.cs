using System.Collections.Generic;
using System.Linq;
using ChainOfResponsibility.Sandbox.COR.Implementation;

namespace ChainOfResponsibility.Sandbox.Mapping
{
    public class MappingResult<T> : IMappingResult<T>
    {
        public T Entity { get; set; }

        public List<ParserWarning> Errors { get; set; }

        public bool IsMapped => !Errors.Any();
    }
}
