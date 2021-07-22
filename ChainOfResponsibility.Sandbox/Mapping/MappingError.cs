namespace ChainOfResponsibility.Sandbox.Mapping
{
    public class MappingError
    {
        public MappingErrorSeverity Severity { get; set; } = MappingErrorSeverity.Error;
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public string Message { get; set; }

        public MappingError(string message)
        {
            Message = message;
        }
    }
}