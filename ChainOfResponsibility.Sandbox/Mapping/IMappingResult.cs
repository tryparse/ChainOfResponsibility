using System.Collections.Generic;
using ChainOfResponsibility.Sandbox.COR.Implementation;

namespace ChainOfResponsibility.Sandbox.Mapping
{
    public interface IMappingResult<T>
    {
        T Entity { get; }

        List<ParserWarning> Errors { get; }

        bool IsMapped { get; }
    }
}
