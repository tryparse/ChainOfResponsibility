using System.Collections.Generic;

namespace ChainOfResponsibility.Sandbox.Mapping
{
    public interface IMappingResult<T>
    {
        T Entity { get; }

        List<MappingError> Errors { get; }

        bool IsMapped { get; }
    }
}
