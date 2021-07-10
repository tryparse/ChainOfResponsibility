namespace ChainOfResponsibility.Sandbox.COR.Core
{
    public abstract class Handler<TRequest> : IHandler<TRequest> where TRequest : class
    {
        private IHandler<TRequest> Next { get; set; }

        public virtual void Handle(TRequest context)
        {
            Next?.Handle(context);
        }

        public IHandler<TRequest> SetNext(IHandler<TRequest> next)
        {
            Next = next;
            return Next;
        }
    }
}
