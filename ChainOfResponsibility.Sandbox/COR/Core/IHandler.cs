namespace ChainOfResponsibility.Sandbox.COR.Core
{
    public interface IHandler<T> where T : class
    {
        IHandler<T> SetNext(IHandler<T> next);
        void Handle(T request);
    }
}
