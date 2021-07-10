namespace ChainOfResponsibility.Sandbox.Runners
{
    public enum RunnerType
    {
        Simple = 0,
        CoR = 1
    }

    public interface IRunner
    {
        void Run();
    }
}
