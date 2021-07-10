namespace ChainOfResponsibility.Sandbox.Mapping
{
    public interface IMapper<T1, T2>
    {
        IMappingResult<T2> Map(T1 sourceEntity);
    }
}
