using System;
using ChainOfResponsibility.Sandbox.Mapping;

namespace ChainOfResponsibility.Sandbox.COR.Core
{
    public class MappingHandler<TRequest, TMappingSource, TMappingResult> : Handler<TRequest>, IHandler<TRequest>
        where TRequest: class 
    {
        protected readonly IMapper<TMappingSource, TMappingResult> _mapper;

        public MappingHandler(IMapper<TMappingSource, TMappingResult> mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override void Handle(TRequest context)
        {
            base.Handle(context);
        }
    }
}
